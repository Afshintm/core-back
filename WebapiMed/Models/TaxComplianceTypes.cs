using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace WebapiMed.Models
{
    public enum ComplianceTypes
    {
        [Description("Company tax return")]
        ctr,
        [Description("Activity statement")]
        bas,
        [Description("Partnership tax return")]
        ptr,
        [Description("Fund tax return")]
        fitr,
        [Description("Individual tax return")]
        iitr,
        [Description("Trust tax return")]
        trt,
        [Description("Self managed super fund")]
        smsfar,

        NotSpecified,

        [Description("IR3 Individual")]
        ir3iitr,

        [Description("IR4 Company")]
        ir4ctr,
        
        [Description("IR3NR Non-resident individual")]
        ir3nritr,

        [Description("IR6 Trust")]
        ir6trt,

        [Description("IR7 Company")]
        ir7ctr,

        [Description("IR7 Partnership")]
        ir7ptr,

        [Description("IR8 Company")]
        ir8ctr,
        [Description("IR8 Maori authority trust")]
        ir8ttr,

        [Description("IR9 Clubs and societies")]
        ir9cas,

        [Description("IR526 Tax credit claim form")]
        ir526tcc
    }

    public class Metadata{
        public string Lable{ get; set; }
        public ComplianceTypes ComplianceType {get;set;}
        public DateTime PeriodStart{get;set;}
        public string CreationUrl {get;set;}
        public static Metadata CreateFromTypeName(string name){
            if (string.IsNullOrEmpty(name)) return null ;

            var complianceType = (ComplianceTypes)Enum.Parse(typeof(ComplianceTypes),name);
            var result = new Metadata{
                Lable = name,
                ComplianceType = complianceType,
                CreationUrl = GetRoute(complianceType),
                PeriodStart = DateTime.Now
            };
            return result ;
        }

        private static string GetRoute(ComplianceTypes complianceType)
        {
            switch(complianceType){
                case ComplianceTypes.ir3iitr:   return ComplianceRoutes.Ir3Individual.Path;
                case ComplianceTypes.ir4ctr:    return ComplianceRoutes.Ir4Company.Path;
                case ComplianceTypes.ir3nritr:  return ComplianceRoutes.Ir3NonResidentIndividual.Path;
                case ComplianceTypes.ir6trt:    return ComplianceRoutes.Ir6Trust.Path;
                case ComplianceTypes.ir7ctr:    return ComplianceRoutes.Ir7Company.Path;
                case ComplianceTypes.ir7ptr:    return ComplianceRoutes.Ir7Partnership.Path;
                case ComplianceTypes.ir8ctr:    return ComplianceRoutes.Ir8Company.Path;
                case ComplianceTypes.ir8ttr:    return ComplianceRoutes.Ir8Trust.Path;
                case ComplianceTypes.ir9cas:    return ComplianceRoutes.Ir9ClubsAndSocieties.Path;
                case ComplianceTypes.ir526tcc:  return ComplianceRoutes.Ir526TaxCreditClaim.Path;
                default: return string.Empty;
        }
    }
    }
    public class viewModel{
        public viewModel(){
            ComplianceList = new List<Metadata>() ;
        }
        public IEnumerable<Metadata> ComplianceList{get;set;}
        public IEnumerable<Metadata> PopulateData(){

            var atype = typeof(ComplianceTypes);
            var enumNames = atype.GetEnumNames();
            var enumValues = atype.GetEnumValues();

            // var e = ComplianceTypes.ctr ;
            // var enumName = atype.GetEnumName(e);
            // var c = (ComplianceTypes)Enum.Parse(typeof(ComplianceTypes),enumName);

            // foreach (var item in enumNames)
            // {
            //     yield return new Metadata{
            //         ComplianceType = (ComplianceTypes)Enum.Parse(typeof(ComplianceTypes),item),
            //         Lable = item,
            //         PeriodStart = DateTime.Now,
            //         CreationUrl= GetRoute(item)
            //     };
            // }

            foreach (var item in enumNames)
            {
                yield return Metadata.CreateFromTypeName(item);
            }

        }

        private string GetRoute(string item)
        {
            if (string.IsNullOrEmpty(item)) return string.Empty;

            switch(item){
                case "ir3iitr":   return ComplianceRoutes.Ir3Individual.Path;
                case "ir4ctr":    return ComplianceRoutes.Ir4Company.Path;
                case "ir3nritr":  return ComplianceRoutes.Ir3NonResidentIndividual.Path;
                case "ir6trt":    return ComplianceRoutes.Ir6Trust.Path;
                case "ir7ctr":    return ComplianceRoutes.Ir7Company.Path;
                case "ir7ptr":    return ComplianceRoutes.Ir7Partnership.Path;
                case "ir8ctr":    return ComplianceRoutes.Ir8Company.Path;
                case "ir8ttr":    return ComplianceRoutes.Ir8Trust.Path;
                case "ir9cas":    return ComplianceRoutes.Ir9ClubsAndSocieties.Path;
                case "ir526tcc":  return ComplianceRoutes.Ir526TaxCreditClaim.Path;
                default: return string.Empty;
                
                    
            } 
        }
    }
}