using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Xml.Serialization;
using TAMU.GeoInnovation.PointIntersectors.Census.OutputData.CensusRecords;
using USC.GISResearchLab.Census.Core.Configurations.ServerConfigurations;
using USC.GISResearchLab.Core.WebServices.ResultCodes;
using USC.GISResearchLab.Geocoding.Core.Metadata.FeatureMatchingResults;

namespace USC.GISResearchLab.Geocoding.Core.OutputData.WebServices
{
    [Serializable]
    public class WebServiceGeocodeQueryResultSet
    {

        #region Properties

        public double Version { get; set; }
        public string TransactionId { get; set; }
        public string MicroMatchStatus { get; set; }


        public QueryStatusCodes QueryStatusCodes { get; set; }

        public List<WebServiceGeocodeQueryResult> WebServiceGeocodeQueryResults {get;set;}

        public string QueryStatusCodeName
        {
            get { return QueryResultCodeManager.GetStatusCodeName(QueryStatusCodes); }
            set { ; }
        }

        public int QueryStatusCodeValue
        {
            get { return QueryResultCodeManager.GetStatusCodeValue(QueryStatusCodes); }
            set { ; }
        }

        public string TimeTaken { get; set; }

        [XmlIgnore]
        public Exception Exception { get; set; }

        public bool ExceptionOccurred { get; set; }
        public string ErrorMessage { get; set; }

        #region Input Address Fields

        public bool IIsPreParsed { get; set; }
        public string INonParsedStreetAddress { get; set; }
        public string INumber { get; set; }
        public string INumberFractional { get; set; }
        public string IPreDirectional { get; set; }
        public string IPreType { get; set; }
        public string IPreQualifier { get; set; }
        public string IPreArticle { get; set; }
        public string IName { get; set; }
        public string ISuffix { get; set; }
        public string IPostArticle { get; set; }
        public string IPostQualifier { get; set; }
        public string IPostDirectional { get; set; }
        public string ISuiteType { get; set; }
        public string ISuiteNumber { get; set; }
        public string ICity { get; set; }
        public string IConsolidatedCity { get; set; }
        public string IMinorCivilDivision { get; set; }
        public string ICountySubRegion { get; set; }
        public string ICounty { get; set; }
        public string IState { get; set; }
        public string IZip { get; set; }
        public string IZipPlus1 { get; set; }
        public string IZipPlus2 { get; set; }
        public string IZipPlus3 { get; set; }
        public string IZipPlus4 { get; set; }
        public string IZipPlus5 { get; set; }
        public string IPostOfficeBoxType { get; set; }
        public string IPostOfficeBoxNumber { get; set; }

        public FeatureMatchingResultType FeatureMatchingResultType { get; set; }
        public int FeatureMatchingResultCount { get; set; }

        #endregion


        #endregion

        public WebServiceGeocodeQueryResultSet()
            : this(4.01)
        {
        }

        public WebServiceGeocodeQueryResultSet(double version)
        {
            QueryStatusCodes = QueryStatusCodes.Unknown;
            WebServiceGeocodeQueryResults = new List<WebServiceGeocodeQueryResult>();
            TransactionId = "";
            MicroMatchStatus = "";
            
            ErrorMessage = "";

            

            INonParsedStreetAddress = "";
            INumber = "";
            INumberFractional = "";
            IPreDirectional = "";
            IPreQualifier = "";
            IPreType = "";
            IPreArticle = "";
            IName = "";
            IPostArticle = "";
            IPostQualifier = "";
            ISuffix = "";
            IPostDirectional = "";
            ISuiteNumber = "";
            ISuiteType = "";
            IPostOfficeBoxType = "";
            IPostOfficeBoxNumber = "";
            ICity = "";
            IConsolidatedCity = "";
            IMinorCivilDivision = "";
            ICountySubRegion = "";
            ICounty = "";
            IState = "";
            IZip = "";
            IZipPlus1 = "";
            IZipPlus2 = "";
            IZipPlus3 = "";
            IZipPlus4 = "";
            IZipPlus5 = "";

           
            Version = version;

        }

        public DataTable ToDataTable()
        {
            DataTable ret = new DataTable();

            try
            {

                ret.Columns.Add("Latitude");
                ret.Columns.Add("Longitude");
                ret.Columns.Add("Quality");
                ret.Columns.Add("NAACCRCensusTractCertaintyCode");
                ret.Columns.Add("NAACCRCensusTractCertaintyName");
                ret.Columns.Add("NAACCRGISCoordinateQualityCode");
                ret.Columns.Add("NAACCRGISCoordinateQualityName");


                ret.Columns.Add("MatchedLocationType");

                ret.Columns.Add("QueryStatusCodes");
                ret.Columns.Add("QueryStatusCodeValue");
                ret.Columns.Add("QueryStatusCodeName");



                ret.Columns.Add("FeatureMatchingGeographyType");
                ret.Columns.Add("FeatureMatchingResultType");
                ret.Columns.Add("GeocodeQualityType");
                ret.Columns.Add("MatchScore");
                ret.Columns.Add("MicroMatchStatus");
                ret.Columns.Add("Version");
                ret.Columns.Add("InterpolationType");
                ret.Columns.Add("InterpolationSubType");

                ret.Columns.Add("TimeTakenOverall");
                ret.Columns.Add("TransactionId");

                ret.Columns.Add("RelaxableAttributes");
                ret.Columns.Add("SoundexAttributes");
                ret.Columns.Add("UseRelaxation");
                ret.Columns.Add("UseSoundex");
                ret.Columns.Add("UseSubstring");
                ret.Columns.Add("UseUncertainty");
                ret.Columns.Add("UseCaching");
                ret.Columns.Add("ReferenceSources");

                ret.Columns.Add("PreParsed");


                ret.Columns.Add("InStreetAddress");

                ret.Columns.Add("InCity");
                ret.Columns.Add("InState");
                ret.Columns.Add("InZip");

                ret.Columns.Add("Census1990Year");
                ret.Columns.Add("Census1990Block");
                ret.Columns.Add("Census1990BlockGroup");
                ret.Columns.Add("Census1990Tract");
                ret.Columns.Add("Census1990CountyFips");
                ret.Columns.Add("Census1990StateFips");
                ret.Columns.Add("Census1990CBSA");
                ret.Columns.Add("Census1990CBSAMicro");
                ret.Columns.Add("Census1990MCD");
                ret.Columns.Add("Census1990MetDiv");
                ret.Columns.Add("Census1990MSAFips");
                ret.Columns.Add("Census1990PlaceFips");

                ret.Columns.Add("Census2000Year");
                ret.Columns.Add("Census2000Block");
                ret.Columns.Add("Census2000BlockGroup");
                ret.Columns.Add("Census2000Tract");
                ret.Columns.Add("Census2000CountyFips");
                ret.Columns.Add("Census2000StateFips");
                ret.Columns.Add("Census2000CBSA");
                ret.Columns.Add("Census2000CBSAMicro");
                ret.Columns.Add("Census2000MCD");
                ret.Columns.Add("Census2000MetDiv");
                ret.Columns.Add("Census2000MSAFips");
                ret.Columns.Add("Census2000PlaceFips");

                ret.Columns.Add("Census2010Year");
                ret.Columns.Add("Census2010Block");
                ret.Columns.Add("Census2010BlockGroup");
                ret.Columns.Add("Census2010Tract");
                ret.Columns.Add("Census2010CountyFips");
                ret.Columns.Add("Census2010StateFips");
                ret.Columns.Add("Census2010CBSA");
                ret.Columns.Add("Census2010CBSAMicro");
                ret.Columns.Add("Census2010MCD");
                ret.Columns.Add("Census2010MetDiv");
                ret.Columns.Add("Census2010MSAFips");
                ret.Columns.Add("Census2010PlaceFips");


                ret.Columns.Add("ParsedName");
                ret.Columns.Add("ParsedNumber");
                ret.Columns.Add("ParsedNumberFractional");
                ret.Columns.Add("ParsedPostArticle");
                ret.Columns.Add("ParsedPostDirectional");
                ret.Columns.Add("ParsedPostQualifier");
                ret.Columns.Add("ParsedPreDirectional");
                ret.Columns.Add("ParsedPreQualifier");
                ret.Columns.Add("ParsedPreType");
                ret.Columns.Add("ParsedPreArticle");
                ret.Columns.Add("ParsedSuiteNumber");
                ret.Columns.Add("ParsedSuiteType");
                ret.Columns.Add("ParsedSuffix");
                ret.Columns.Add("ParsedCity");
                ret.Columns.Add("ParsedConsolidatedCity");
                ret.Columns.Add("ParsedMinorCivilDivision");
                ret.Columns.Add("ParsedCountySubregion");
                ret.Columns.Add("ParsedCounty");
                ret.Columns.Add("ParsedState");
                ret.Columns.Add("ParsedZip");
                ret.Columns.Add("ParsedZipPlus1");
                ret.Columns.Add("ParsedZipPlus2");
                ret.Columns.Add("ParsedZipPlus3");
                ret.Columns.Add("ParsedZipPlus4");
                ret.Columns.Add("ParsedZipPlus5");
                ret.Columns.Add("ParsedPostOfficeBoxType");
                ret.Columns.Add("ParsedPostOfficeBoxNumber");

                ret.Columns.Add("MatchedName");
                ret.Columns.Add("MatchedNumber");
                ret.Columns.Add("MatchedNumberFractional");
                ret.Columns.Add("MatchedPostArticle");
                ret.Columns.Add("MatchedPostDirectional");
                ret.Columns.Add("MatchedPostQualifier");
                ret.Columns.Add("MatchedPreDirectional");
                ret.Columns.Add("MatchedPreQualifier");
                ret.Columns.Add("MatchedPreArticle");
                ret.Columns.Add("MatchedPreType");
                ret.Columns.Add("MatchedSuiteNumber");
                ret.Columns.Add("MatchedSuiteType");
                ret.Columns.Add("MatchedSuffix");
                ret.Columns.Add("MatchedCity");
                ret.Columns.Add("MatchedConsolidatedCity");
                ret.Columns.Add("MatchedMinorCivilDivision");
                ret.Columns.Add("MatchedCountySubRegion");
                ret.Columns.Add("MatchedCounty");
                ret.Columns.Add("MatchedState");
                ret.Columns.Add("MatchedZip");
                ret.Columns.Add("MatchedZipPlus1");
                ret.Columns.Add("MatchedZipPlus2");
                ret.Columns.Add("MatchedZipPlus3");
                ret.Columns.Add("MatchedZipPlus4");
                ret.Columns.Add("MatchedZipPlus5");
                ret.Columns.Add("MatchedPostOfficeBoxType");
                ret.Columns.Add("MatchedPostOfficeBoxNumber");

                ret.Columns.Add("MatchedFeatureName");
                ret.Columns.Add("MatchedFeatureNumber");
                ret.Columns.Add("MatchedFeatureNumberFractional");
                ret.Columns.Add("MatchedFeaturePostArticle");
                ret.Columns.Add("MatchedFeaturePostDirectional");
                ret.Columns.Add("MatchedFeaturePostQualifier");
                ret.Columns.Add("MatchedFeaturePreDirectional");
                ret.Columns.Add("MatchedFeaturePreQualifier");
                ret.Columns.Add("MatchedFeaturePreArticle");
                ret.Columns.Add("MatchedFeaturePreType");
                ret.Columns.Add("MatchedFeatureSuiteNumber");
                ret.Columns.Add("MatchedFeatureSuiteType");
                ret.Columns.Add("MatchedFeatureSuffix");
                ret.Columns.Add("MatchedFeatureCity");
                ret.Columns.Add("MatchedFeatureConsolidatedCity");
                ret.Columns.Add("MatchedFeatureMinorCivilDivision");
                ret.Columns.Add("MatchedFeatureCountySubRegion");
                ret.Columns.Add("MatchedFeatureCounty");
                ret.Columns.Add("MatchedFeatureState");
                ret.Columns.Add("MatchedFeatureZip");
                ret.Columns.Add("MatchedFeatureZipPlus1");
                ret.Columns.Add("MatchedFeatureZipPlus2");
                ret.Columns.Add("MatchedFeatureZipPlus3");
                ret.Columns.Add("MatchedFeatureZipPlus4");
                ret.Columns.Add("MatchedFeatureZipPlus5");
                ret.Columns.Add("MatchedFeaturePostOfficeBoxType");
                ret.Columns.Add("MatchedFeaturePostOfficeBoxNumber");

                ret.Columns.Add("MatchedFeatureSource");
                ret.Columns.Add("MatchedFeatureVintage");
                ret.Columns.Add("MatchedFeatureArea");
                ret.Columns.Add("MatchedFeatureAreaType");
                ret.Columns.Add("MatchedFeatureGeometrySRID");
                ret.Columns.Add("MatchedFeatureGeometry");
                ret.Columns.Add("MatchedFeaturePrimaryIdField");
                ret.Columns.Add("MatchedFeaturePrimaryIdValue");
                ret.Columns.Add("MatchedFeatureSecondaryIdField");
                ret.Columns.Add("MatchedFeatureSecondaryIdValue");

                foreach (WebServiceGeocodeQueryResult webServiceGeocodeQueryResult in WebServiceGeocodeQueryResults)
                {
                    if (webServiceGeocodeQueryResult != null)
                    {
                        DataRow dataRow = ret.NewRow();

                        dataRow["Latitude"] = webServiceGeocodeQueryResult.Latitude;
                        dataRow["Longitude"] = webServiceGeocodeQueryResult.Longitude;
                        dataRow["Quality"] = webServiceGeocodeQueryResult.Quality;
                        dataRow["MatchedLocationType"] = webServiceGeocodeQueryResult.MatchedLocationType;
                        dataRow["QueryStatusCodes"] = webServiceGeocodeQueryResult.QueryStatusCodes;
                        dataRow["QueryStatusCodeValue"] = webServiceGeocodeQueryResult.QueryStatusCodeValue;
                        dataRow["QueryStatusCodeName"] = webServiceGeocodeQueryResult.QueryStatusCodeName;

                        dataRow["NAACCRCensusTractCertaintyCode"] = webServiceGeocodeQueryResult.NAACCRCensusTractCertaintyCode;
                        dataRow["NAACCRCensusTractCertaintyName"] = webServiceGeocodeQueryResult.NAACCRCensusTractCertaintyName;

                        dataRow["NAACCRGISCoordinateQualityCode"] = webServiceGeocodeQueryResult.NAACCRGISCoordinateQualityCode;
                        dataRow["NAACCRGISCoordinateQualityName"] = webServiceGeocodeQueryResult.NAACCRGISCoordinateQualityName;


                        dataRow["FeatureMatchingGeographyType"] = webServiceGeocodeQueryResult.FeatureMatchingGeographyType;
                        dataRow["FeatureMatchingResultType"] = webServiceGeocodeQueryResult.FeatureMatchingResultType;
                        dataRow["GeocodeQualityType"] = webServiceGeocodeQueryResult.GeocodeQualityType;
                        dataRow["MatchScore"] = webServiceGeocodeQueryResult.MatchScore;
                        if (webServiceGeocodeQueryResult.MicroMatchStatus != null)
                        {
                            dataRow["MicroMatchStatus"] = webServiceGeocodeQueryResult.MicroMatchStatus;
                        }
                        else if (this.MicroMatchStatus != null)
                        {
                            dataRow["MicroMatchStatus"] = this.MicroMatchStatus;
                        }
                        dataRow["Version"] = webServiceGeocodeQueryResult.Version;
                        dataRow["InterpolationType"] = webServiceGeocodeQueryResult.InterpolationType;
                        dataRow["InterpolationSubType"] = webServiceGeocodeQueryResult.InterpolationSubType;

                        dataRow["TimeTakenOverall"] = webServiceGeocodeQueryResult.TimeTaken;
                        dataRow["TransactionId"] = webServiceGeocodeQueryResult.TransactionId;

                        //dataRow["RelaxableAttributes"] = webServiceGeocodeQueryResult.RelaxableAttributes;
                        //dataRow["SoundexAttributes"] = webServiceGeocodeQueryResult.SoundexAttributes;
                        //dataRow["UseRelaxation"] = webServiceGeocodeQueryResult.UseRelaxation;
                        //dataRow["UseSoundex"] = webServiceGeocodeQueryResult.UseSoundex;
                        //dataRow["UseSubstring"] = webServiceGeocodeQueryResult.UseSubstring;
                        //dataRow["UseUncertainty"] = webServiceGeocodeQueryResult.UseUncertainty;
                        //dataRow["UseCaching"] = webServiceGeocodeQueryResult.UseCaching;
                        //dataRow["ReferenceSources"] = webServiceGeocodeQueryResult.ReferenceSources;

                        //dataRow["PreParsed"] = webServiceGeocodeQueryResult.PreParsed;


                        //dataRow["InStreetAddress"] = webServiceGeocodeQueryResult.InStreetAddress;

                        //dataRow["InCity"] = webServiceGeocodeQueryResult.InCity;
                        //dataRow["InState"] = webServiceGeocodeQueryResult.InState;
                        //dataRow["InZip"] = webServiceGeocodeQueryResult.InZip;

                        if (webServiceGeocodeQueryResult.CensusRecords != null && webServiceGeocodeQueryResult.CensusRecords.Count > 0)
                        {
                            foreach (CensusOutputRecord censusRecord in webServiceGeocodeQueryResult.CensusRecords)
                            {
                                switch (censusRecord.CensusYear)
                                {
                                    case CensusYear.NineteenNinety:
                                        dataRow["Census1990Year"] = censusRecord.CensusYear;
                                        dataRow["Census1990Block"] = censusRecord.CensusBlock;
                                        dataRow["Census1990BlockGroup"] = censusRecord.CensusBlockGroup;
                                        dataRow["Census1990Tract"] = censusRecord.CensusTract;
                                        dataRow["Census1990CountyFips"] = censusRecord.CensusCountyFips;
                                        dataRow["Census1990StateFips"] = censusRecord.CensusStateFips;
                                        dataRow["Census1990CBSA"] = censusRecord.CensusCbsaFips;
                                        dataRow["Census1990CBSAMicro"] = censusRecord.CensusCbsaMicro;
                                        dataRow["Census1990MCD"] = censusRecord.CensusMcdFips;
                                        dataRow["Census1990MetDiv"] = censusRecord.CensusMetDivFips;
                                        dataRow["Census1990MSAFips"] = censusRecord.CensusMsaFips;
                                        dataRow["Census1990PlaceFips"] = censusRecord.CensusPlaceFips;
                                        //dataRow["CensusException"] = webServiceGeocodeQueryResult.;
                                        break;
                                    case CensusYear.TwoThousand:
                                        dataRow["Census2000Year"] = censusRecord.CensusYear;
                                        dataRow["Census2000Block"] = censusRecord.CensusBlock;
                                        dataRow["Census2000BlockGroup"] = censusRecord.CensusBlockGroup;
                                        dataRow["Census2000Tract"] = censusRecord.CensusTract;
                                        dataRow["Census2000CountyFips"] = censusRecord.CensusCountyFips;
                                        dataRow["Census2000StateFips"] = censusRecord.CensusStateFips;
                                        dataRow["Census2000CBSA"] = censusRecord.CensusCbsaFips;
                                        dataRow["Census2000CBSAMicro"] = censusRecord.CensusCbsaMicro;
                                        dataRow["Census2000MCD"] = censusRecord.CensusMcdFips;
                                        dataRow["Census2000MetDiv"] = censusRecord.CensusMetDivFips;
                                        dataRow["Census2000MSAFips"] = censusRecord.CensusMsaFips;
                                        dataRow["Census2000PlaceFips"] = censusRecord.CensusPlaceFips;
                                        //dataRow["CensusException"] = webServiceGeocodeQueryResult.;
                                        break;
                                    case CensusYear.TwoThousandTen:
                                        dataRow["Census2010Year"] = censusRecord.CensusYear;
                                        dataRow["Census2010Block"] = censusRecord.CensusBlock;
                                        dataRow["Census2010BlockGroup"] = censusRecord.CensusBlockGroup;
                                        dataRow["Census2010Tract"] = censusRecord.CensusTract;
                                        dataRow["Census2010CountyFips"] = censusRecord.CensusCountyFips;
                                        dataRow["Census2010StateFips"] = censusRecord.CensusStateFips;
                                        dataRow["Census2010CBSA"] = censusRecord.CensusCbsaFips;
                                        dataRow["Census2010CBSAMicro"] = censusRecord.CensusCbsaMicro;
                                        dataRow["Census2010MCD"] = censusRecord.CensusMcdFips;
                                        dataRow["Census2010MetDiv"] = censusRecord.CensusMetDivFips;
                                        dataRow["Census2010MSAFips"] = censusRecord.CensusMsaFips;
                                        dataRow["Census2010PlaceFips"] = censusRecord.CensusPlaceFips;
                                        //dataRow["CensusException"] = webServiceGeocodeQueryResult.;
                                        break;
                                    default:
                                        throw new Exception("Unexpected census year: " + censusRecord.CensusYear);
                                }
                            }
                        }
                        else if (webServiceGeocodeQueryResult.CensusYear != CensusYear.Unknown)
                        {
                            switch (webServiceGeocodeQueryResult.CensusYear)
                            {
                                case CensusYear.NineteenNinety:
                                    dataRow["Census1990Year"] = webServiceGeocodeQueryResult.CensusYear;
                                    dataRow["Census1990Block"] = webServiceGeocodeQueryResult.CensusBlock;
                                    dataRow["Census1990BlockGroup"] = webServiceGeocodeQueryResult.CensusBlockGroup;
                                    dataRow["Census1990Tract"] = webServiceGeocodeQueryResult.CensusTract;
                                    dataRow["Census1990CountyFips"] = webServiceGeocodeQueryResult.CensusCountyFips;
                                    dataRow["Census1990StateFips"] = webServiceGeocodeQueryResult.CensusStateFips;
                                    dataRow["Census1990CBSA"] = webServiceGeocodeQueryResult.CensusCbsaFips;
                                    dataRow["Census1990CBSAMicro"] = webServiceGeocodeQueryResult.CensusCbsaMicro;
                                    dataRow["Census1990MCD"] = webServiceGeocodeQueryResult.CensusMcdFips;
                                    dataRow["Census1990MetDiv"] = webServiceGeocodeQueryResult.CensusMetDivFips;
                                    dataRow["Census1990MSAFips"] = webServiceGeocodeQueryResult.CensusMsaFips;
                                    dataRow["Census1990PlaceFips"] = webServiceGeocodeQueryResult.CensusPlaceFips;
                                    //dataRow["CensusException"] = webServiceGeocodeQueryResult.;
                                    break;
                                case CensusYear.TwoThousand:
                                    dataRow["Census2000Year"] = webServiceGeocodeQueryResult.CensusYear;
                                    dataRow["Census2000Block"] = webServiceGeocodeQueryResult.CensusBlock;
                                    dataRow["Census2000BlockGroup"] = webServiceGeocodeQueryResult.CensusBlockGroup;
                                    dataRow["Census2000Tract"] = webServiceGeocodeQueryResult.CensusTract;
                                    dataRow["Census2000CountyFips"] = webServiceGeocodeQueryResult.CensusCountyFips;
                                    dataRow["Census2000StateFips"] = webServiceGeocodeQueryResult.CensusStateFips;
                                    dataRow["Census2000CBSA"] = webServiceGeocodeQueryResult.CensusCbsaFips;
                                    dataRow["Census2000CBSAMicro"] = webServiceGeocodeQueryResult.CensusCbsaMicro;
                                    dataRow["Census2000MCD"] = webServiceGeocodeQueryResult.CensusMcdFips;
                                    dataRow["Census2000MetDiv"] = webServiceGeocodeQueryResult.CensusMetDivFips;
                                    dataRow["Census2000MSAFips"] = webServiceGeocodeQueryResult.CensusMsaFips;
                                    dataRow["Census2000PlaceFips"] = webServiceGeocodeQueryResult.CensusPlaceFips;
                                    //dataRow["CensusException"] = webServiceGeocodeQueryResult.;
                                    break;
                                case CensusYear.TwoThousandTen:
                                    dataRow["Census2010Year"] = webServiceGeocodeQueryResult.CensusYear;
                                    dataRow["Census2010Block"] = webServiceGeocodeQueryResult.CensusBlock;
                                    dataRow["Census2010BlockGroup"] = webServiceGeocodeQueryResult.CensusBlockGroup;
                                    dataRow["Census2010Tract"] = webServiceGeocodeQueryResult.CensusTract;
                                    dataRow["Census2010CountyFips"] = webServiceGeocodeQueryResult.CensusCountyFips;
                                    dataRow["Census2010StateFips"] = webServiceGeocodeQueryResult.CensusStateFips;
                                    dataRow["Census2010CBSA"] = webServiceGeocodeQueryResult.CensusCbsaFips;
                                    dataRow["Census2010CBSAMicro"] = webServiceGeocodeQueryResult.CensusCbsaMicro;
                                    dataRow["Census2010MCD"] = webServiceGeocodeQueryResult.CensusMcdFips;
                                    dataRow["Census2010MetDiv"] = webServiceGeocodeQueryResult.CensusMetDivFips;
                                    dataRow["Census2010MSAFips"] = webServiceGeocodeQueryResult.CensusMsaFips;
                                    dataRow["Census2010PlaceFips"] = webServiceGeocodeQueryResult.CensusPlaceFips;
                                    //dataRow["CensusException"] = webServiceGeocodeQueryResult.;
                                    break;
                                default:
                                    throw new Exception("Unexpected census year: " + webServiceGeocodeQueryResult.CensusYear);
                            }
                        }

                        dataRow["ParsedName"] = webServiceGeocodeQueryResult.PName;
                        dataRow["ParsedNumber"] = webServiceGeocodeQueryResult.PNumber;
                        dataRow["ParsedNumberFractional"] = webServiceGeocodeQueryResult.PNumberFractional;
                        dataRow["ParsedPostArticle"] = webServiceGeocodeQueryResult.PPostArticle;
                        dataRow["ParsedPostDirectional"] = webServiceGeocodeQueryResult.PPostDirectional;
                        dataRow["ParsedPostQualifier"] = webServiceGeocodeQueryResult.PPostQualifier;
                        dataRow["ParsedPreDirectional"] = webServiceGeocodeQueryResult.PPreDirectional;
                        dataRow["ParsedPreQualifier"] = webServiceGeocodeQueryResult.PPreQualifier;
                        dataRow["ParsedPreType"] = webServiceGeocodeQueryResult.PPreType;
                        dataRow["ParsedPreArticle"] = webServiceGeocodeQueryResult.PPreArticle;
                        dataRow["ParsedSuiteNumber"] = webServiceGeocodeQueryResult.PSuiteNumber;
                        dataRow["ParsedSuiteType"] = webServiceGeocodeQueryResult.PSuiteType;
                        dataRow["ParsedSuffix"] = webServiceGeocodeQueryResult.PSuffix;
                        dataRow["ParsedCity"] = webServiceGeocodeQueryResult.PCity;
                        dataRow["ParsedConsolidatedCity"] = webServiceGeocodeQueryResult.PConsolidatedCity;
                        dataRow["ParsedMinorCivilDivision"] = webServiceGeocodeQueryResult.PMinorCivilDivision;
                        dataRow["ParsedCountySubregion"] = webServiceGeocodeQueryResult.PCountySubRegion;
                        dataRow["ParsedCounty"] = webServiceGeocodeQueryResult.PCounty;
                        dataRow["ParsedState"] = webServiceGeocodeQueryResult.PState;
                        dataRow["ParsedZip"] = webServiceGeocodeQueryResult.PZip;
                        dataRow["ParsedZipPlus1"] = webServiceGeocodeQueryResult.PZipPlus1;
                        dataRow["ParsedZipPlus2"] = webServiceGeocodeQueryResult.PZipPlus2;
                        dataRow["ParsedZipPlus3"] = webServiceGeocodeQueryResult.PZipPlus3;
                        dataRow["ParsedZipPlus4"] = webServiceGeocodeQueryResult.PZipPlus4;
                        dataRow["ParsedZipPlus5"] = webServiceGeocodeQueryResult.PZipPlus5;
                        dataRow["ParsedPostOfficeBoxType"] = webServiceGeocodeQueryResult.PPostOfficeBoxType;
                        dataRow["ParsedPostOfficeBoxNumber"] = webServiceGeocodeQueryResult.PPostOfficeBoxNumber;

                        dataRow["MatchedName"] = webServiceGeocodeQueryResult.MName;
                        dataRow["MatchedNumber"] = webServiceGeocodeQueryResult.MNumber;
                        dataRow["MatchedNumberFractional"] = webServiceGeocodeQueryResult.MNumberFractional;
                        dataRow["MatchedPostArticle"] = webServiceGeocodeQueryResult.MPostArticle;
                        dataRow["MatchedPostDirectional"] = webServiceGeocodeQueryResult.MPostDirectional;
                        dataRow["MatchedPostQualifier"] = webServiceGeocodeQueryResult.MPostQualifier;
                        dataRow["MatchedPreDirectional"] = webServiceGeocodeQueryResult.MPreDirectional;
                        dataRow["MatchedPreQualifier"] = webServiceGeocodeQueryResult.MPreQualifier;
                        dataRow["MatchedPreType"] = webServiceGeocodeQueryResult.MPreType;
                        dataRow["MatchedPreArticle"] = webServiceGeocodeQueryResult.MPreArticle;
                        dataRow["MatchedSuiteNumber"] = webServiceGeocodeQueryResult.MSuiteNumber;
                        dataRow["MatchedSuiteType"] = webServiceGeocodeQueryResult.MSuiteType;
                        dataRow["MatchedSuffix"] = webServiceGeocodeQueryResult.MSuffix;
                        dataRow["MatchedCity"] = webServiceGeocodeQueryResult.MCity;
                        dataRow["MatchedConsolidatedCity"] = webServiceGeocodeQueryResult.MConsolidatedCity;
                        dataRow["MatchedMinorCivilDivision"] = webServiceGeocodeQueryResult.MMinorCivilDivision;
                        dataRow["MatchedCountySubregion"] = webServiceGeocodeQueryResult.MCountySubRegion;
                        dataRow["MatchedCounty"] = webServiceGeocodeQueryResult.MCounty;
                        dataRow["MatchedState"] = webServiceGeocodeQueryResult.MState;
                        dataRow["MatchedZip"] = webServiceGeocodeQueryResult.MZip;
                        dataRow["MatchedZipPlus1"] = webServiceGeocodeQueryResult.MZipPlus1;
                        dataRow["MatchedZipPlus2"] = webServiceGeocodeQueryResult.MZipPlus2;
                        dataRow["MatchedZipPlus3"] = webServiceGeocodeQueryResult.MZipPlus3;
                        dataRow["MatchedZipPlus4"] = webServiceGeocodeQueryResult.MZipPlus4;
                        dataRow["MatchedZipPlus5"] = webServiceGeocodeQueryResult.MZipPlus5;
                        dataRow["MatchedPostOfficeBoxType"] = webServiceGeocodeQueryResult.MPostOfficeBoxType;
                        dataRow["MatchedPostOfficeBoxNumber"] = webServiceGeocodeQueryResult.MPostOfficeBoxNumber;

                        dataRow["MatchedFeatureName"] = webServiceGeocodeQueryResult.FName;
                        dataRow["MatchedFeatureNumber"] = webServiceGeocodeQueryResult.FNumber;
                        dataRow["MatchedFeatureNumberFractional"] = webServiceGeocodeQueryResult.FNumberFractional;
                        dataRow["MatchedFeaturePostArticle"] = webServiceGeocodeQueryResult.FPostArticle;
                        dataRow["MatchedFeaturePostDirectional"] = webServiceGeocodeQueryResult.FPostDirectional;
                        dataRow["MatchedFeaturePostQualifier"] = webServiceGeocodeQueryResult.FPostQualifier;
                        dataRow["MatchedFeaturePreDirectional"] = webServiceGeocodeQueryResult.FPreDirectional;
                        dataRow["MatchedFeaturePreQualifier"] = webServiceGeocodeQueryResult.FPreQualifier;
                        dataRow["MatchedFeaturePreType"] = webServiceGeocodeQueryResult.FPreType;
                        dataRow["MatchedFeaturePreArticle"] = webServiceGeocodeQueryResult.FPreArticle;
                        dataRow["MatchedFeatureSuiteNumber"] = webServiceGeocodeQueryResult.FSuiteNumber;
                        dataRow["MatchedFeatureSuiteType"] = webServiceGeocodeQueryResult.FSuiteType;
                        dataRow["MatchedFeatureSuffix"] = webServiceGeocodeQueryResult.FSuffix;
                        dataRow["MatchedFeatureCity"] = webServiceGeocodeQueryResult.FCity;
                        dataRow["MatchedFeatureConsolidatedCity"] = webServiceGeocodeQueryResult.FConsolidatedCity;
                        dataRow["MatchedFeatureMinorCivilDivision"] = webServiceGeocodeQueryResult.FMinorCivilDivision;
                        dataRow["MatchedFeatureCountySubregion"] = webServiceGeocodeQueryResult.FCountySubRegion;
                        dataRow["MatchedFeatureCounty"] = webServiceGeocodeQueryResult.FCounty;
                        dataRow["MatchedFeatureState"] = webServiceGeocodeQueryResult.FState;
                        dataRow["MatchedFeatureZip"] = webServiceGeocodeQueryResult.FZip;
                        dataRow["MatchedFeatureZipPlus1"] = webServiceGeocodeQueryResult.FZipPlus1;
                        dataRow["MatchedFeatureZipPlus2"] = webServiceGeocodeQueryResult.FZipPlus2;
                        dataRow["MatchedFeatureZipPlus3"] = webServiceGeocodeQueryResult.FZipPlus3;
                        dataRow["MatchedFeatureZipPlus4"] = webServiceGeocodeQueryResult.FZipPlus4;
                        dataRow["MatchedFeatureZipPlus5"] = webServiceGeocodeQueryResult.FZipPlus5;
                        dataRow["MatchedFeaturePostOfficeBoxType"] = webServiceGeocodeQueryResult.FPostOfficeBoxType;
                        dataRow["MatchedFeaturePostOfficeBoxNumber"] = webServiceGeocodeQueryResult.FPostOfficeBoxNumber;

                        dataRow["MatchedFeatureSource"] = webServiceGeocodeQueryResult.FSource;
                        dataRow["MatchedFeatureVintage"] = webServiceGeocodeQueryResult.FVintage;
                        dataRow["MatchedFeatureArea"] = webServiceGeocodeQueryResult.FArea;
                        dataRow["MatchedFeatureAreaType"] = webServiceGeocodeQueryResult.FAreaType;
                        dataRow["MatchedFeatureGeometrySRID"] = webServiceGeocodeQueryResult.FGeometrySRID;
                        dataRow["MatchedFeatureGeometry"] = webServiceGeocodeQueryResult.FGeometry;
                        dataRow["MatchedFeaturePrimaryIdField"] = webServiceGeocodeQueryResult.FPrimaryIdField;
                        dataRow["MatchedFeaturePrimaryIdValue"] = webServiceGeocodeQueryResult.FPrimaryIdValue;
                        dataRow["MatchedFeatureSecondaryIdField"] = webServiceGeocodeQueryResult.FSecondaryIdField;
                        dataRow["MatchedFeatureSecondaryIdValue"] = webServiceGeocodeQueryResult.FSecondaryIdValue;

                        ret.Rows.Add(dataRow);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Exception in WebServiceGeocodeQueryResult.ToDataTable() - " + ex.Message);
            }

            return ret;
        }

        public string AsString(string separator)
        {
            return AsString(separator, Version);
        }

        public string AsString(string separator, double version)
        {
            string ret = "";
           
                ret = AsStringVerbose(separator, version);
            
            return ret;
        }

        public string AsHeaderString(string separator)
        {
            return AsHeaderString(separator, Version);
        }

        public string AsHeaderString(string separator, double version)
        {
            string ret = "";
            
                ret = AsHeaderStringVerbose(separator, version);
            
            return ret;
        }

        public string AsStringVerbose(string separator)
        {
            return AsStringVerbose(separator, Version);
        }

        public string AsHeaderStringVerbose(string separator)
        {
            return AsHeaderStringVerbose(separator, Version);
        }

        public string AsStringVerbose(string separator, double version)
        {
            string ret = null;

            if (version < 4.0)
            {
                ret = AsStringVerbose_V03_01(separator, version);
            }
            else
            {
                ret = AsStringVerbose_V04_01(separator, version);
            }
            
            return ret;
        }

        public string AsHeaderStringVerbose(string separator, double version)
        {
            string ret = null;
            if (version < 4.0)
            {
                ret = AsHeaderStringVerbose_V03_01(separator, version);
            }
            else if (version >= 4.0)
            {
                ret = AsHeaderStringVerbose_V04_01(separator, version);
            }
            else
            {
                throw new Exception("Unsupported or unimplemented version number: " + version);
            }
            return ret;
        }


        public string AsString_V03_01(string separator, double version)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(TransactionId).Append(separator); //0
            sb.Append(Version).Append(separator); //1
            sb.Append(QueryStatusCodeValue).Append(separator); //2
            sb.Append(TimeTaken).Append(separator); //3

            
            return sb.ToString();
        }

        public string AsHeaderString_V03_01(string separator, double version)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("TransactionId").Append(separator); //0
            sb.Append("Version").Append(separator); //1
            sb.Append("QueryStatusCodeValue").Append(separator); //2
            sb.Append("TimeTaken").Append(separator); //3

            return sb.ToString();
        }

        public string AsStringWithCensus_V03_01(string separator, double version)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(TransactionId).Append(separator); //0
            sb.Append(Version).Append(separator); //1
            sb.Append(QueryStatusCodeValue).Append(separator); //2
            sb.Append(TimeTaken).Append(separator); //3


            return sb.ToString();
        }

        public string AsHeaderStringWithCensus_V03_01(string separator, double version)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("TransactionId").Append(separator); //0
            sb.Append("Version").Append(separator); //1
            sb.Append("QueryStatusCodeValue").Append(separator); //2
            sb.Append("TimeTaken").Append(separator); //3

            return sb.ToString();
        }

        public string AsStringVerbose_V03_01(string separator, double version)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(TransactionId).Append(separator); //0
            sb.Append(Version).Append(separator); //1
            sb.Append(QueryStatusCodeValue).Append(separator); //2
            sb.Append(TimeTaken).Append(separator); //3


            return sb.ToString();
        }

        public string AsHeaderStringVerbose_V03_01(string separator, double version)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("TransactionId").Append(separator); //0
            sb.Append("Version").Append(separator); //1
            sb.Append("QueryStatusCodeValue").Append(separator); //2
            sb.Append("TimeTaken").Append(separator); //3

            return sb.ToString();
        }


        // v 4.01

        public string AsString_V04_01(string separator, double version)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(TransactionId).Append(separator); //0
            sb.Append(Version).Append(separator); //1
            sb.Append(QueryStatusCodeValue).Append(separator); //2
            sb.Append(TimeTaken).Append(separator); //3


            return sb.ToString();
        }

        public string AsHeaderString_V04_01(string separator, double version)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("TransactionId").Append(separator); //0
            sb.Append("Version").Append(separator); //1
            sb.Append("QueryStatusCodeValue").Append(separator); //2
            sb.Append("TimeTaken").Append(separator); //3

            return sb.ToString();
        }

        public string AsStringWithCensus_V04_01(string separator, double version)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(TransactionId).Append(separator); //0
            sb.Append(Version).Append(separator); //1
            sb.Append(QueryStatusCodeValue).Append(separator); //2
            sb.Append(TimeTaken).Append(separator); //3


            return sb.ToString();
        }

        public string AsHeaderStringWithCensus_V04_01(string separator, double version)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("TransactionId").Append(separator); //0
            sb.Append("Version").Append(separator); //1
            sb.Append("QueryStatusCodeValue").Append(separator); //2
            sb.Append("TimeTaken").Append(separator); //3

            return sb.ToString();
        }

        public string AsStringVerbose_V04_01(string separator, double version)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(TransactionId).Append(separator); //0
            sb.Append(Version).Append(separator); //1
            sb.Append(QueryStatusCodeValue).Append(separator); //2
            sb.Append(TimeTaken).Append(separator); //3


            return sb.ToString();
        }

        public string AsHeaderStringVerbose_V04_01(string separator, double version)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("TransactionId").Append(separator); //0
            sb.Append("Version").Append(separator); //1
            sb.Append("QueryStatusCodeValue").Append(separator); //2
            sb.Append("TimeTaken").Append(separator); //3

            return sb.ToString();
        }      
        
        public override string ToString()
        {
            return ToString(false);
        }

        public string ToString(bool verbose)
        {
            string ret = "";
            if (!verbose)
            {
                ret = AsString(",", Version);
            }
            else
            {
                ret = AsStringVerbose(",", Version);
            }

            return ret;
        }

        //PAYTON:MICROMATCHSTATUS we need to determine the actual micro match status here - this is just a placeholder
        public bool GetMicroMatchStatus()
        {
            bool ret = false;
            // Coordinate code should not be used here as a street segment should be a viable match as well as parcel, point etc
            //if (this.WebServiceGeocodeQueryResults[0].NAACCRGISCoordinateQualityCode == "00" && this.WebServiceGeocodeQueryResults[0].MatchScore > 90)
            if (this.WebServiceGeocodeQueryResults[0].MatchScore > 90)
                {
                if (this.WebServiceGeocodeQueryResults[0].FCity != null && this.WebServiceGeocodeQueryResults[0].FZip != null)
                {
                    if (this.ICity.ToUpper() == this.WebServiceGeocodeQueryResults[0].FCity.ToUpper() && this.IZip == this.WebServiceGeocodeQueryResults[0].FZip)
                    {
                        this.MicroMatchStatus = "Match";
                    }
                    else
                    {
                        this.MicroMatchStatus = "Review";
                    }
                }
                else
                {
                    this.MicroMatchStatus = "Review";
                }
            }
            else //anything not match or review is returned as non-match
            {
                this.MicroMatchStatus = "Non-Match";
            }
            return ret;
        }


    }
}
