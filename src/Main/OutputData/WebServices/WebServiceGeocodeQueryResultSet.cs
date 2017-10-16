using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Xml.Serialization;
using TAMU.GeoInnovation.PointIntersectors.Census.OutputData.CensusRecords;
using USC.GISResearchLab.Census.Core.Configurations.ServerConfigurations;
//using USC.GISResearchLab.Common.Geometries.Points;
using System.Drawing;
using USC.GISResearchLab.Core.WebServices.ResultCodes;
using USC.GISResearchLab.Geocoding.Core.Metadata.FeatureMatchingResults;
using USC.GISResearchLab.AddressProcessing.Core.Standardizing.StandardizedAddresses.Lines.LastLines;
using Tamu.GeoInnovation.Geocoding.Core.Algorithms.PenaltyScoring;

namespace USC.GISResearchLab.Geocoding.Core.OutputData.WebServices
{
    [Serializable]
    public class WebServiceGeocodeQueryResultSet
    {

        #region Properties

        public double Version { get; set; }
        public string TransactionId { get; set; }
        public string MicroMatchStatus { get; set; }
        public PenaltyCodeResult PenaltyCodeResult { get; set; }
        public string PenaltyCode { get; set; }

        public int parcelMatches = 0;
        public int streetMatches = 0;
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
            if (version > 4.0)
            {
                MicroMatchStatus = "";
            }
            
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
                ret.Columns.Add("PenaltyCodeResult");
                ret.Columns.Add("PenaltyCode");                
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
                        //PAYTON:PENALTYCODE handle same as micromatch status above
                        if (webServiceGeocodeQueryResult.PenaltyCode != null)
                        {
                            dataRow["PenaltyCode"] = webServiceGeocodeQueryResult.PenaltyCode;
                        }
                        else if (this.PenaltyCode != null)
                        {
                            dataRow["PenaltyCode"] = this.PenaltyCode;
                        }
                        if (webServiceGeocodeQueryResult.PenaltyCodeResult != null)
                        {
                            dataRow["PenaltyCodeResult"] = webServiceGeocodeQueryResult.PenaltyCodeResult;
                        }
                        else if (this.PenaltyCodeResult != null)
                        {
                            dataRow["PenaltyCodeResult"] = this.PenaltyCodeResult;
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
            //this.PenaltyCodeResult = new PenaltyCodeResult();
            if (this.WebServiceGeocodeQueryResults.Count > 0) //if no geocodes - return non-match
            {
                if (this.WebServiceGeocodeQueryResults[0].MatchScore < 100)
                {
                    if (this.WebServiceGeocodeQueryResults[0].MatchScore > 88)
                    {
                        if (this.WebServiceGeocodeQueryResults[0].FCity != null && this.WebServiceGeocodeQueryResults[0].FZip != null)
                        {
                            //PAYTON:MICROMATCHSTATUS If score is less than 98 don't assume it's a match without performing distance/census match test
                            if (this.ICity.ToUpper() == this.WebServiceGeocodeQueryResults[0].FCity.ToUpper() && this.IZip == this.WebServiceGeocodeQueryResults[0].FZip && this.WebServiceGeocodeQueryResults[0].MatchScore > 97)
                            {
                                this.MicroMatchStatus = "Match";                               
                            }
                            //Here we need to check against other results
                            //if city is correct but zip is not, check other results
                            else
                            {
                                this.MicroMatchStatus = "Review";
                                parcelMatches = 0;
                                streetMatches = 0;
                                double avgParcelDistance = getAverageDistance("parcel");
                                double avgStreetDistance = getAverageDistance("street");
                                //If the average distance is less than 1/5 of a mile - assume it's a good match
                                //Adding a count check as well to account for all navteq references to return a non-valid match but all the same coords
                                //if count is > 5 it's safe to assume that multiple references are reporting the same location for the address
                                if (avgParcelDistance < .05 && parcelMatches > 1 && getCensusMatchStatus())
                                {
                                    this.MicroMatchStatus = "Match";
                                }
                                if (parcelMatches == 0 && streetMatches > 1 && avgStreetDistance < .05 && getCensusMatchStatus())
                                {
                                    this.MicroMatchStatus = "Match";
                                }
                            }
                        }
                        else
                        {
                            this.MicroMatchStatus = "Review";
                        }
                    }
                    else //match score is less than 88 so return non match
                    {
                        this.MicroMatchStatus = "Non-Match";
                    }
                }
                else //if we reach here matchscore is 100 so return match
                {
                    //PAYTON:PENALTYCODE
                    //if city is alias - update penalty
                    //if (WebServiceGeocodeQueryResults[0].FCity != WebServiceGeocodeQueryResults[0].PCity && CityUtils.isValidAlias(WebServiceGeocodeQueryResults[0].FCity, WebServiceGeocodeQueryResults[0].PCity, WebServiceGeocodeQueryResults[0].PState))
                    //{
                    //    this.PenaltyCodeResult.city = 1;
                    //}
                    this.MicroMatchStatus = "Match";
                }                
            }
            else //no geocodes so return non-match
            {
                this.MicroMatchStatus = "Non-Match";
            }
            
            //scoreResult.Add(penalty.AddressComponent.ToString(), penalty.PenaltyValue.ToString());
            
            //this.PenaltyCodeResult.getPenalty(scoreResult);
            //this.PenaltyCode = this.PenaltyCodeResult.getPenaltyString();
            return ret;
        }

        public double getAverageDistance(string type)
        {
            //int num_points = WebServiceGeocodeQueryResults.Count;
            int num_points = 0;
            
            //List<Point> normalPoints = new List<Point>();
            List<PointF> points = new List<PointF>();
            foreach (var resultPoint in WebServiceGeocodeQueryResults)
            {
                //normalPoints.Add(new Point(Convert.ToInt32(resultPoint.Longitude), Convert.ToInt32(resultPoint.Latitude)));
                if (type == "parcel")
                {
                    if (resultPoint.NAACCRGISCoordinateQualityType == Metadata.Qualities.NAACCRGISCoordinateQualityType.AddressPoint ||
                       resultPoint.NAACCRGISCoordinateQualityType == Metadata.Qualities.NAACCRGISCoordinateQualityType.Parcel)
                    {
                        points.Add(new PointF(Convert.ToSingle(resultPoint.Longitude), Convert.ToSingle(resultPoint.Latitude)));
                        parcelMatches++;
                        num_points++;
                    }
                }
                else if (type == "street")
                {
                    if (resultPoint.NAACCRGISCoordinateQualityType == Metadata.Qualities.NAACCRGISCoordinateQualityType.StreetCentroid ||
                        resultPoint.NAACCRGISCoordinateQualityType == Metadata.Qualities.NAACCRGISCoordinateQualityType.StreetIntersection ||
                        resultPoint.NAACCRGISCoordinateQualityType == Metadata.Qualities.NAACCRGISCoordinateQualityType.StreetSegmentInterpolation)
                    {
                        points.Add(new PointF(Convert.ToSingle(resultPoint.Longitude), Convert.ToSingle(resultPoint.Latitude)));
                        streetMatches++;
                        num_points++;
                    }
                }
            }
            PointF[] pts = new PointF[num_points];
            points.CopyTo(pts, 0);
            //pts[num_points] = points[0];
            float area = 0;
            double distance = 0;
            double distanceAvg = 0;
            if (points.Count > 1)
            {
                for (int i = 0; i < num_points-1; i++)
                {
                    //area +=
                    //    (pts[i + 1].X - pts[i].X) *
                    //    (pts[i + 1].Y + pts[i].Y) / 2;
                    double dX = pts[0].X - pts[i + 1].X;
                    double dY = pts[0].Y - pts[i + 1].Y;
                    double multi = dX * dX + dY * dY;
                    distance = distance + Math.Round(Math.Sqrt(multi), 3);
                }
                distanceAvg = ((distance) / (num_points-1)) * 100;
            }
            else
            {
                distanceAvg = 0;
            }                       
            return distanceAvg;
        }

        public bool getCensusMatchStatus()
        {
            bool censusMatches = true;
            if (WebServiceGeocodeQueryResults[0].CensusRecords.Count > 0)
            {
                string censusTract = WebServiceGeocodeQueryResults[0].CensusRecords[0].CensusTract.ToString();
                string censusBlock = WebServiceGeocodeQueryResults[0].CensusRecords[0].CensusBlock.ToString();
                string countyFips = WebServiceGeocodeQueryResults[0].CensusRecords[0].CensusCountyFips.ToString();
                foreach (var geocode in WebServiceGeocodeQueryResults)
                {
                    if (geocode.CensusRecords[0].CensusBlock != censusBlock)
                    {
                        censusMatches = false;
                        break;
                    }
                    else if (geocode.CensusRecords[0].CensusTract != censusTract)
                    {
                        censusMatches = false;
                        break;
                    }
                    else if (geocode.CensusRecords[0].CensusCountyFips != countyFips)
                    {
                        censusMatches = false;
                        break;
                    }
                }
            }
            else
            {
                censusMatches = false;
            }
            return censusMatches;
        }
    }
}
