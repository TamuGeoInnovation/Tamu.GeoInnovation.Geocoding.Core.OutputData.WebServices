using System.Text;
using USC.GISResearchLab.Common.Addresses;
using USC.GISResearchLab.Common.Core.JSON;
using USC.GISResearchLab.Core.WebServices.ResultCodes;

namespace USC.GISResearchLab.Geocoding.Core.OutputData.WebServices
{
    public class DeterministicNormalizationServiceResult
    {

        #region Properties


        public string TransactionId { get; set; }

        #region ResultCodes

        public QueryStatusCodes QueryStatusCodes { get; set; }

        public string QueryStatusCodeName
        {
            get { return QueryResultCodeManager.GetStatusCodeName(QueryStatusCodes); }
            set {; }
        }

        public int QueryStatusCodeValue
        {
            get { return QueryResultCodeManager.GetStatusCodeValue(QueryStatusCodes); }
            set {; }
        }

        #endregion

        #region Parsed Address Fields

        public double Version { get; set; }
        public string Number { get; set; }
        public string NumberFractional { get; set; }
        public string PreDirectional { get; set; }
        public string PreQualifier { get; set; }
        public string PreType { get; set; }
        public string PreArticle { get; set; }
        //public string StreetName { get; set; }
        public string Name { get; set; }
        public string Suffix { get; set; }
        public string PostArticle { get; set; }
        public string PostQualifier { get; set; }
        public string PostDirectional { get; set; }
        public string SuiteType { get; set; }
        public string SuiteNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string ZipPlus1 { get; set; }
        public string ZipPlus2 { get; set; }
        public string ZipPlus3 { get; set; }
        public string ZipPlus4 { get; set; }
        public string ZipPlus5 { get; set; }
        public string PostOfficeBoxType { get; set; }
        public string PostOfficeBoxNumber { get; set; }


        #endregion

        #endregion

        public DeterministicNormalizationServiceResult()
        {


        }

        public string ToJSON()
        {
            StringBuilder sb = new StringBuilder();


            sb.Append("{").AppendLine();
            sb.Append("\t\"TransactionId\" : \"").Append(JSONUtils.CleanText(TransactionId)).Append("\",").AppendLine();
            sb.Append("\t\"Version\"   : \"").Append(JSONUtils.CleanText(Version)).Append("\",").AppendLine();
            sb.Append("\t\"QueryStatusCode\" : \"").Append(JSONUtils.CleanText(QueryStatusCodes.ToString())).Append("\",").AppendLine();
            sb.Append("\t\"StreetAddresses\" : ").AppendLine();
            sb.Append("\t[").AppendLine();

            sb.Append("\t\t{").AppendLine();
            sb.Append("\t\t\"Number\" : \"").Append(JSONUtils.CleanText(Number)).Append("\",").AppendLine();
            sb.Append("\t\t\"NumberFractional\" : \"").Append(JSONUtils.CleanText(NumberFractional)).Append("\",").AppendLine();
            sb.Append("\t\t\"PreDirectional\" : \"").Append(JSONUtils.CleanText(PreDirectional)).Append("\",").AppendLine();
            sb.Append("\t\t\"PreQualifier\" : \"").Append(JSONUtils.CleanText(PreQualifier)).Append("\",").AppendLine();
            sb.Append("\t\t\"PreType\" : \"").Append(JSONUtils.CleanText(PreType)).Append("\",").AppendLine();
            sb.Append("\t\t\"PreArticle\" : \"").Append(JSONUtils.CleanText(PreArticle)).Append("\",").AppendLine();
            sb.Append("\t\t\"StreetName\" : \"").Append(JSONUtils.CleanText(Name)).Append("\",").AppendLine();
            sb.Append("\t\t\"Suffix\" : \"").Append(JSONUtils.CleanText(Suffix)).Append("\",").AppendLine();
            sb.Append("\t\t\"PostArticle\" : \"").Append(JSONUtils.CleanText(PostArticle)).Append("\",").AppendLine();
            sb.Append("\t\t\"PostQualifier\" : \"").Append(JSONUtils.CleanText(PostQualifier)).Append("\",").AppendLine();
            sb.Append("\t\t\"PostDirectional\" : \"").Append(JSONUtils.CleanText(PostDirectional)).Append("\",").AppendLine();
            sb.Append("\t\t\"SuiteType\" : \"").Append(JSONUtils.CleanText(SuiteType)).Append("\",").AppendLine();
            sb.Append("\t\t\"SuiteNumber\" : \"").Append(JSONUtils.CleanText(SuiteNumber)).Append("\",").AppendLine();
            sb.Append("\t\t\"City\" : \"").Append(JSONUtils.CleanText(City)).Append("\",").AppendLine();
            sb.Append("\t\t\"State\" : \"").Append(JSONUtils.CleanText(State)).Append("\",").AppendLine();
            sb.Append("\t\t\"ZIP\" : \"").Append(JSONUtils.CleanText(Zip)).Append("\",").AppendLine();
            sb.Append("\t\t\"ZIPPlus1\" : \"").Append(JSONUtils.CleanText(ZipPlus1)).Append("\",").AppendLine();
            sb.Append("\t\t\"ZIPPlus2\" : \"").Append(JSONUtils.CleanText(ZipPlus2)).Append("\",").AppendLine();
            sb.Append("\t\t\"ZIPPlus3\" : \"").Append(JSONUtils.CleanText(ZipPlus3)).Append("\",").AppendLine();
            sb.Append("\t\t\"ZIPPlus4\" : \"").Append(JSONUtils.CleanText(ZipPlus4)).Append("\",").AppendLine();
            sb.Append("\t\t\"ZIPPlus5\" : \"").Append(JSONUtils.CleanText(ZipPlus5)).Append("\",").AppendLine();
            sb.Append("\t\t\"PostOfficeBoxType\" : \"").Append(JSONUtils.CleanText(PostOfficeBoxType)).Append("\",").AppendLine();
            sb.Append("\t\t\"PostOfficeBoxNumber\" : \"").Append(JSONUtils.CleanText(PostOfficeBoxNumber)).Append("\"").AppendLine();
            sb.Append("\t\t}").AppendLine();

            sb.Append("\t]").AppendLine();


            sb.Append("}").AppendLine();


            return sb.ToString();
        }

        public override string ToString()
        {
            return ToString(false);
        }

        public StreetAddress ToStreetAddress()
        {

            StreetAddress ret = new StreetAddress();

            ret.Version = this.Version;
            ret.Number = this.Number;
            ret.NumberFractional = this.NumberFractional;
            ret.PreDirectional = this.PreDirectional;
            ret.PreQualifier = this.PreQualifier;
            ret.PreType = this.PreType;
            ret.PreArticle = this.PreArticle;
            //ret.StreetName = this.StreetName;
            ret.StreetName = this.Name;
            ret.Suffix = this.Suffix;
            ret.PostArticle = this.PostArticle;
            ret.PostQualifier = this.PostQualifier;
            ret.PostDirectional = this.PostDirectional;
            ret.SuiteType = this.SuiteType;
            ret.SuiteNumber = this.SuiteNumber;
            ret.City = this.City;
            ret.State = this.State;
            ret.ZIP = this.Zip;
            ret.ZIPPlus1 = this.ZipPlus1;
            ret.ZIPPlus2 = this.ZipPlus2;
            ret.ZIPPlus3 = this.ZipPlus3;
            ret.ZIPPlus4 = this.ZipPlus4;
            ret.ZIPPlus5 = this.ZipPlus5;
            ret.PostOfficeBoxType = this.PostOfficeBoxType;
            ret.PostOfficeBoxNumber = this.PostOfficeBoxNumber;


            return ret;
        }

        public string ToString(bool verbose)
        {
            return AsStringVerbose(",", Version);
        }

        public string ToCSV(string separator, double version)
        {
            return AsStringVerbose(",", version);
        }

        public string AsStringVerbose(string separator, double version)
        {
            string ret = "";
            ret += Number + separator;
            ret += NumberFractional + separator;
            ret += PreDirectional + separator;
            ret += PreQualifier + separator;
            ret += PreType + separator;
            ret += PreArticle + separator;
            //ret += StreetName + separator;
            ret += Name + separator;
            ret += PostArticle + separator;
            ret += Suffix + separator;
            ret += PostQualifier + separator;
            ret += PostDirectional + separator;
            ret += SuiteType + separator;
            ret += SuiteNumber + separator;
            ret += PostOfficeBoxType + separator;
            ret += PostOfficeBoxNumber + separator;
            ret += City + separator;
            ret += State + separator;
            ret += Zip + separator;
            ret += ZipPlus4 + separator;
            ret += ZipPlus3 + separator;
            ret += ZipPlus2 + separator;
            ret += ZipPlus1 + separator;
            ret += ZipPlus5;

            return ret;
        }



    }
}
