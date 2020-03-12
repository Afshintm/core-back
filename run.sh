#!/bin/bash

OPS_TYPE=$1
CMD_TYPE=$2

RED_TEXT=`tput setaf 1`
CYAN_TEXT=`tput setaf 6`
YELLOW_TEXT=`tput setaf 3`
GREEN_TEXT=`tput setaf 2`
RESET_TEXT=`tput sgr0`

function build_api {
  echo "${CYAN_TEXT}*** Building API ***${RESET_TEXT}"
  dotnet build WebApiMed
}

function build_docker {
  echo ${CYAN_TEXT}*** Stopping containers ***${RESET_TEXT}
  docker-compose -f local-env-compose.yml down
  echo
  echo "${CYAN_TEXT}*** Building containers ***${RESET_TEXT}"
  docker-compose build
  echo
  echo "${CYAN_TEXT}*** Docker build completed! ***${RESET_TEXT}"
  echo "${RESET_TEXT}"
}


function run_docker {
  echo ${CYAN_TEXT}*** Stopping containers ***${RESET_TEXT}
  docker-compose -f local-env-compose.yml down
  echo
  echo "${CYAN_TEXT}*** Starting local environment containers ***${RESET_TEXT}"
  docker-compose -f local-env-compose.yml up
  echo
  echo "${CYAN_TEXT}*** Containers running! ***${RESET_TEXT}"
  echo "${RESET_TEXT}"
}

function run_api {
  local environment="$1"
  local description="$2"
  export ASPNETCORE_ENVIRONMENT=$environment

  echo
  echo "${CYAN_TEXT}*** Running API with Project launch-profile  ${description} aka ASPNETCORE_ENVIRONMENT=${environment} ***${RESET_TEXT}"
  dotnet run --project WebapiMed/WebapiMed.csproj
}

function run_api_env {
  local environment="$1"
  local description="$2"
  export ASPNETCORE_ENVIRONMENT=$environment

  echo
  echo "${CYAN_TEXT}*** Running API --no-launch-profile  ${description} aka ASPNETCORE_ENVIRONMENT=${environment} ***${RESET_TEXT}"
  #ASPNETCORE_URLS=https://*:5001 
  dotnet run --project WebapiMed/WebapiMed.csproj --no-launch-profile --urls="https://*:5061;http://*:5060"
  #ASPNETCORE_ENVIRONMENT=$environment dotnet run --project WebapiMed --no-launch-profile
}

function run_unit_tests {
  echo
  echo ${GREEN_TEXT}*** Running Unit tests ***${RESET_TEXT}
  echo
  export GREP_OPTIONS='--color=always'
  export GREP_COLOR='1;35;40'
  dotnet test ./tests/Tax.Compliance.Tests --verbosity normal
}

function run_component_tests {
  echo
  echo ${RED_TEXT}*** Remember in SIT only run component tests individually ***${RESET_TEXT}
  echo ${RED_TEXT}*** Remember to first spin up containers and run API ***${RESET_TEXT}
  echo
  echo ${GREEN_TEXT}*** Running Component tests ***${RESET_TEXT}
  echo
  dotnet test ./tests/Tax.Compliance.ComponentsTests
  echo ${GREEN_TEXT}*** Running Form Management Component tests ***${RESET_TEXT}
  echo
  dotnet test ./tests/Tax.Compliance.FormManagement.Component.Tests
}

function run_integration_tests {
  echo
  echo ${RED_TEXT}*** Remember Integration Tests will run against sit services ***${RESET_TEXT}
  echo ${RED_TEXT}*** Remember run myob-auth login before running integration tests ***${RESET_TEXT}
  echo
  echo ${GREEN_TEXT}*** Running Integration tests ***${RESET_TEXT}
  echo
  source ./run.sh get secrets:dev && dotnet test ./tests/Tax.Compliance.Integration.Tests
  echo ${GREEN_TEXT}*** Running Form Management Component tests ***${RESET_TEXT}
  echo
}

function print_usage {
  echo "Usage:"
  echo "${CYAN_TEXT}./run.sh build api"
  echo "${GREEN_TEXT}./run.sh run   docker"
  echo "${GREEN_TEXT}./run.sh run   api:stubs"
  echo "${GREEN_TEXT}./run.sh run   api:sit"
  echo "${GREEN_TEXT}./run.sh run   api:development/|staging|production"
  echo "${YELLOW_TEXT}./run.sh test  unit"
  echo "${YELLOW_TEXT}./run.sh test  component"
  echo "${YELLOW_TEXT}./run.sh test  integration"
  echo "${RED_TEXT}./run.sh get secrets:dev"
  echo "${RESET_TEXT}"
  exit
}

if [ "$OPS_TYPE" = "" ] || [ "$CMD_TYPE" = "" ]; then
  print_usage
fi

if [ $OPS_TYPE = "build" ]; then
  if [ $CMD_TYPE = "api" ]; then
    build_api
  else
    print_usage
  fi
elif [ $OPS_TYPE = "run" ]; then
  if [ $CMD_TYPE = "build:docker" ]; then
    build_docker
  elif [ $CMD_TYPE = "docker" ]; then
    run_docker
  elif [ $CMD_TYPE = "api" ]; then
    run_api "Development" "Stubs"
  elif [ $CMD_TYPE = "api:development" ]; then
    run_api_env "Development" "Real Endpoints"
  elif [ $CMD_TYPE = "api:staging" ]; then
    run_api_env "Staging" "Real Endpoints"
  elif [ $CMD_TYPE = "api:production" ]; then
    run_api_env "Production" "Real Endpoints"
  else
    print_usage
  fi
elif  [ $OPS_TYPE = "get" ]; then
  if [ $CMD_TYPE = "secrets:dev" ]; then
    get_secrets
  else
    print_usage
  fi
elif [ $OPS_TYPE = "test" ]; then
  if [ $CMD_TYPE = "unit" ]; then
    run_unit_tests
  elif [ $CMD_TYPE = "component" ]; then
    run_component_tests
  elif [ $CMD_TYPE = "integration" ]; then
    run_integration_tests
  else
    print_usage
  fi
else
  print_usage
fi
