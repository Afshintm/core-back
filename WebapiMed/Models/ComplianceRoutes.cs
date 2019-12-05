namespace WebapiMed.Models{
public static class RoutesConstants
    {
        public const string Relationships = "relationships";
        public const string IdKey = "{Id}";
    }
public static class ComplianceRoutes
    {
        public const string Path = "compliance";
        public const string IdKey = RoutesConstants.IdKey;
        public const string Au = "au";
        public const string Nz = "nz";

        public static class TaxReturn
        {
            public const string Path = "taxreturn";
            public const string BaseUrl = IdKey + "/" + Path;
            public const string RelationshipUrl = IdKey + "/" + RoutesConstants.Relationships + "/" + Path;
        }

        public static class TaxRec
        {
            public const string Path = "taxrec";
            public const string BaseUrl = IdKey + "/" + Path;
            public const string RelationshipUrl = IdKey + "/" + RoutesConstants.Relationships + "/" + Path;
        }

        public static class ComplianceMetaData
        {
            public const string Path = "complianceviewmetadata";
            public const string BaseUrl = IdKey + "/" + Path;
        }

        public static class CreateCompliance
        {
            public const string Path = "create";
            public const string ObligationsNotificationUrl = Path + "/ObligationsNotification/{paramsWipId}";
            public const string PrefillNotificationUrl = Path + "/PrefillNotification/{paramsWipId}";
            public const string ParamsWipIdUrl = Path + "/{paramsWipId}";
        }
        public static class ManualCreateCompliance
        {
            public const string Path = "manualcreate";
        }

        public static class ActivityStatement
        {
            public const string Path = "activitystatement";
        }

        public static class Company
        {
            public const string Path = Au + "/" + "company";
        }

        public static class Partnership
        {
            public const string Path = Au + "/" + "partnership";
        }

        public static class Fund
        {
            public const string Path = Au + "/" + "fund";
        }

        public static class SelfManagedSuperFund
        {
            public const string Path = Au + "/" + "selfmanagedsuperfund";
        }

        public static class Trust
        {
            public const string Path = Au + "/" + "trust";
        }

        public static class Individual
        {
            public const string Path = Au + "/" + "individual";
        }

        public static class Ir3Individual
        {
            public const string Path = Nz + "/" + "ir3individual";
        }

        public static class Ir4Company
        {
            public const string Path = Nz + "/" + "ir4company";
        }

        public static class Ir3NonResidentIndividual
        {
            public const string Path = Nz + "/" + "ir3nonresidentindividual";
        }
        
        public static class Ir6Trust
        {
            public const string Path = Nz + "/" + "ir6trust";
        }

        public static class Ir7Company
        {
            public const string Path = Nz + "/" + "ir7company";
        }

        public static class Ir7Partnership
        {
            public const string Path = Nz + "/" + "ir7partnership";
        }

        public static class Ir8Company
        {
            public const string Path = Nz + "/" + "ir8company";
        }
        public static class Ir8Trust
        {
            public const string Path = Nz + "/" + "ir8trust";
        }

        public static class Ir9ClubsAndSocieties
        {
            public const string Path = Nz + "/" + "ir9clubsandsocieties";
        }

        public static class Ir526TaxCreditClaim
        {
            public const string Path = Nz + "/" + "ir526taxcreditclaim";
        }
        
        public static class Migration
        {
            public const string Path = "migration";
            public const string Compliances = "compliances";
        }
        public static class DataBinding
        {
            public const string Path = "databinding";
            public const string BaseUrl = IdKey + "/" + Path;
        }

        public static class DataBindingRenew
        {
            public const string Path = "renew";
        }

    }

    public static class ComplianceTypeMetaData{
        public const string Nz = "nz";
        public static class Ir526TaxCreditClaim{
            public static string Label{get;set;}
            public const ComplianceTypes ComplianceType = ComplianceTypes.ir526tcc;
            public const string Path = Nz + "/" + "ir526taxcreditclaim";
        } 

    }
    
    }