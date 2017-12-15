using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using TAMU.GeoInnovation.PointIntersectors.Census.OutputData.CensusRecords;
using USC.GISResearchLab.AddressProcessing.Core.AddressNormalization.Implementations;
using USC.GISResearchLab.Census.Core.Configurations.ServerConfigurations;
using USC.GISResearchLab.Common.Core.Geocoders.FeatureMatching;
using USC.GISResearchLab.Core.WebServices.ResultCodes;
using USC.GISResearchLab.Geocoding.Core.Algorithms.FeatureInterpolationMethods;
using Tamu.GeoInnovation.Geocoding.Core.Algorithms.PenaltyScoring;
using USC.GISResearchLab.Geocoding.Core.Algorithms.TieHandlingMethods;
using USC.GISResearchLab.Geocoding.Core.Metadata;
using USC.GISResearchLab.Geocoding.Core.Metadata.FeatureMatchingResults;
using USC.GISResearchLab.Geocoding.Core.Metadata.Qualities;

namespace USC.GISResearchLab.Geocoding.Core.OutputData.WebServices
{
    [Serializable]
    public class WebServiceGeocodeQueryResult
    {

        #region Properties

        public string TransactionId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Version { get; set; }
        public string Quality { get; set; }
        
        public string MatchedLocationType { get; set; }
        public string MatchType { get; set; }


        public string FeatureMatchingResultCount { get; set; }
        public string FeatureMatchingResultTypeNotes { get; set; }
        public string FeatureMatchingResultTypeTieBreakingNotes { get; set; }
        public TieHandlingStrategyType TieHandlingStrategyType { get; set; }
        public FeatureMatchingSelectionMethod FeatureMatchingSelectionMethod { get; set; }
        public string FeatureMatchingSelectionMethodNotes { get; set; }

        public QueryStatusCodes QueryStatusCodes { get; set; }

        public GeocodeQualityType GeocodeQualityType { get; set; }
        
        public string NAACCRGISCoordinateQualityCode { get; set; }
        public string NAACCRGISCoordinateQualityName { get; set; }
        public NAACCRGISCoordinateQualityType NAACCRGISCoordinateQualityType { get; set; }

        public string NAACCRCensusTractCertaintyCode { get; set; }
        public string NAACCRCensusTractCertaintyName { get; set; }
        public NAACCRCensusTractCertaintyType NAACCRCensusTractCertaintyType { get; set; }
        
        public FeatureMatchingGeographyType FeatureMatchingGeographyType { get; set; }
        public FeatureMatchingResultType FeatureMatchingResultType { get; set; }
        public double MatchScore { get; set; }
        public string MicroMatchStatus { get; set; }
        public PenaltyCodeResult PenaltyCodeResult { get; set; }
        public string PenaltyCode { get; set; }
        public string PenaltyCodeSummary { get; set; }
        public InterpolationType InterpolationType { get; set; }
        public InterpolationSubType InterpolationSubType { get; set; }

        public string RegionSize { get; set; }
        public string RegionSizeUnits { get; set; }

        [XmlIgnore]
        public GeocodeStatistics Statistics { get; set; }

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

        [XmlIgnore]
        public Exception Exception { get; set; }

        public bool ExceptionOccurred { get; set; }
        public string ErrorMessage { get; set; }
        public string TimeTaken { get; set; }

        #region Census Fields

        public List<CensusOutputRecord> CensusRecords { get; set; }
        public CensusYear CensusYear { get; set; }
        public double CensusTimeTaken { get; set; }
        public string CensusStateFips { get; set; }
        public string CensusCountyFips { get; set; }
        public string CensusTract { get; set; }
        public string CensusBlockGroup { get; set; }
        public string CensusBlock { get; set; }
        public string CensusPlaceFips { get; set; }
        public string CensusMcdFips { get; set; }
        public string CensusMsaFips { get; set; }
        public string CensusMetDivFips { get; set; }
        public string CensusCbsaFips { get; set; }
        public string CensusCbsaMicro { get; set; }

        #endregion

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

        #endregion

        #region Matched Address Fields

        public string MNumber { get; set; }
        public string MNumberFractional { get; set; }
        public string MPreDirectional { get; set; }
        public string MPreType { get; set; }
        public string MPreQualifier { get; set; }
        public string MPreArticle { get; set; }
        public string MName { get; set; }
        public string MSuffix { get; set; }
        public string MPostArticle { get; set; }
        public string MPostQualifier { get; set; }
        public string MPostDirectional { get; set; }
        public string MSuiteType { get; set; }
        public string MSuiteNumber { get; set; }
        public string MCity { get; set; }
        public string MConsolidatedCity { get; set; }
        public string MMinorCivilDivision { get; set; }
        public string MCountySubRegion { get; set; }
        public string MCounty { get; set; }
        public string MState { get; set; }
        public string MZip { get; set; }
        public string MZipPlus1 { get; set; }
        public string MZipPlus2 { get; set; }
        public string MZipPlus3 { get; set; }
        public string MZipPlus4 { get; set; }
        public string MZipPlus5 { get; set; }
        public string MPostOfficeBoxType { get; set; }
        public string MPostOfficeBoxNumber { get; set; }

        #endregion

        #region Parsed Address Fields

        public string PNumber { get; set; }
        public string PNumberFractional { get; set; }
        public string PPreDirectional { get; set; }
        public string PPreType { get; set; }
        public string PPreQualifier { get; set; }
        public string PPreArticle { get; set; }
        public string PName { get; set; }
        public string PSuffix { get; set; }
        public string PPostArticle { get; set; }
        public string PPostQualifier { get; set; }
        public string PPostDirectional { get; set; }
        public string PSuiteType { get; set; }
        public string PSuiteNumber { get; set; }
        public string PCity { get; set; }
        public string PConsolidatedCity { get; set; }
        public string PMinorCivilDivision { get; set; }
        public string PCountySubRegion { get; set; }
        public string PCounty { get; set; }
        public string PState { get; set; }
        public string PZip { get; set; }
        public string PZipPlus1 { get; set; }
        public string PZipPlus2 { get; set; }
        public string PZipPlus3 { get; set; }
        public string PZipPlus4 { get; set; }
        public string PZipPlus5 { get; set; }
        public string PPostOfficeBoxType { get; set; }
        public string PPostOfficeBoxNumber { get; set; }


        #endregion

        #region Reference Feature Fields

        public string FNumber { get; set; }
        public string FNumberFractional { get; set; }
        public string FPreDirectional { get; set; }
        public string FPreType { get; set; }
        public string FPreQualifier { get; set; }
        public string FPreArticle { get; set; }
        public string FName { get; set; }
        public string FSuffix { get; set; }
        public string FPostArticle { get; set; }
        public string FPostQualifier { get; set; }
        public string FPostDirectional { get; set; }
        public string FSuiteType { get; set; }
        public string FSuiteNumber { get; set; }
        public string FCity { get; set; }
        public string FConsolidatedCity { get; set; }
        public string FMinorCivilDivision { get; set; }
        public string FCountySubRegion { get; set; }
        public string FCounty { get; set; }
        public string FState { get; set; }
        public string FZip { get; set; }
        public string FZipPlus1 { get; set; }
        public string FZipPlus2 { get; set; }
        public string FZipPlus3 { get; set; }
        public string FZipPlus4 { get; set; }
        public string FZipPlus5 { get; set; }
        public string FPostOfficeBoxType { get; set; }
        public string FPostOfficeBoxNumber { get; set; }
        public string FArea { get; set; }
        public string FAreaType { get; set; }
        public int FGeometrySRID { get; set; }
        public string FGeometry { get; set; }
        public string FSource { get; set; }
        public string FVintage { get; set; }

        public string FPrimaryIdField { get; set; }
        public string FPrimaryIdValue { get; set; }
        public string FSecondaryIdField { get; set; }
        public string FSecondaryIdValue { get; set; }

        #endregion


        #endregion

        public WebServiceGeocodeQueryResult()
            : this(new AddressNormalizer().AddressParserVersion)
        {
        }

        public WebServiceGeocodeQueryResult(double version)
        {
            CensusRecords = new List<CensusOutputRecord>();
            QueryStatusCodes = QueryStatusCodes.Unknown;
            TransactionId = "";
            Latitude = 0.0;
            Longitude = 0.0;
            MatchedLocationType = "";
            MatchType = "";
            Quality = "";

            NAACCRGISCoordinateQualityCode = "";
            NAACCRGISCoordinateQualityName = "";
            NAACCRCensusTractCertaintyCode = "";
            NAACCRCensusTractCertaintyName = "";

            ErrorMessage = "";

            FeatureMatchingResultCount = "";
            FeatureMatchingResultTypeNotes = "";
            FeatureMatchingResultTypeTieBreakingNotes = "";
            FeatureMatchingSelectionMethodNotes = "";

            RegionSize = "";
            RegionSizeUnits = "";

            CensusBlock = "";
            CensusBlockGroup = "";
            CensusCbsaFips = "";
            CensusCbsaMicro = "";
            CensusCountyFips = "";
            CensusPlaceFips = "";
            CensusMcdFips = "";
            CensusMetDivFips = "";
            CensusMsaFips = "";
            CensusStateFips = "";
            CensusTract = "";

            MNumber = "";
            MNumberFractional = "";
            MPreDirectional = "";
            MPreQualifier = "";
            MPreType = "";
            MPreArticle = "";
            MName = "";
            MPostArticle = "";
            MPostQualifier = "";
            MSuffix = "";
            MPostDirectional = "";
            MSuiteNumber = "";
            MSuiteType = "";
            MPostOfficeBoxType = "";
            MPostOfficeBoxNumber = "";
            MCity = "";
            MConsolidatedCity = "";
            MMinorCivilDivision = "";
            MCountySubRegion = "";
            MCounty = "";
            MState = "";
            MZip = "";
            MZipPlus1 = "";
            MZipPlus2 = "";
            MZipPlus3 = "";
            MZipPlus4 = "";
            MZipPlus5 = "";

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

            PNumber = "";
            PNumberFractional = "";
            PPreDirectional = "";
            PPreQualifier = "";
            PPreType = "";
            PPreArticle = "";
            PName = "";
            PPostArticle = "";
            PPostQualifier = "";
            PSuffix = "";
            PPostDirectional = "";
            PSuiteNumber = "";
            PSuiteType = "";
            PPostOfficeBoxType = "";
            PPostOfficeBoxNumber = "";
            PCity = "";
            PConsolidatedCity = "";
            PMinorCivilDivision = "";
            PCountySubRegion = "";
            PCounty = "";
            PState = "";
            PZip = "";
            PZipPlus1 = "";
            PZipPlus2 = "";
            PZipPlus3 = "";
            PZipPlus4 = "";
            PZipPlus5 = "";

            FNumber = "";
            FNumberFractional = "";
            FPreDirectional = "";
            FPreQualifier = "";
            FPreType = "";
            FPreArticle = "";
            FName = "";
            FPostArticle = "";
            FPostQualifier = "";
            FSuffix = "";
            FPostDirectional = "";
            FSuiteNumber = "";
            FSuiteType = "";
            FPostOfficeBoxType = "";
            FPostOfficeBoxNumber = "";
            FCity = "";
            FConsolidatedCity = "";
            FMinorCivilDivision = "";
            FCountySubRegion = "";
            FCounty = "";
            FState = "";
            FZip = "";
            FZipPlus1 = "";
            FZipPlus2 = "";
            FZipPlus3 = "";
            FZipPlus4 = "";
            FZipPlus5 = "";
            FArea = "";
            FAreaType = "";
            FGeometry = "";
            FSource = "";
            FVintage = "";
            FPrimaryIdField = "";
            FPrimaryIdValue = "";
            FSecondaryIdField = "";
            FSecondaryIdValue = "";

            FGeometrySRID = 4269;
            Version = version;

        }

        public string AsString(string separator)
        {
            return AsString(separator, Version);
        }

        public string AsString(string separator, double version)
        {
            string ret = "";
            if (version >= 2.96)
            {
                ret = AsStringVerbose(separator, version);
            }
            return ret;
        }

        public string AsHeaderString(string separator)
        {
            return AsHeaderString(separator, Version);
        }

        public string AsHeaderString(string separator, double version)
        {
            string ret = "";
            if (version >= 3.0)
            {
                ret = AsHeaderStringVerbose(separator, version);
            }
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
            if (version >= 2.96 && version < 3.0)
            {
                ret = AsStringVerbose_V02_96(separator, version);
            }
            else if (version > 3.0 && version < 4.0)
            {
                ret = AsStringVerbose_V03_01(separator, version);
            }
            //PAYTON:V4.02
            else if (version >= 4.0 && version < 4.02)
            {
                ret = AsStringVerbose_V04_01(separator, version);
            }
            else if (version >= 4.02 && version < 4.03)
            {
                ret = AsStringVerbose_V04_02(separator, version);
            }
            //PAYTON:V4.03
            else if (version >= 4.03 && version < 4.04)
            {
                ret = AsStringVerbose_V04_03(separator, version);
            }
            else if (Version >= 4.04 && Version != 4.3)
            {
                ret = AsStringVerbose_V04_04(separator, version);
            }
            else
            {
                throw new Exception("Unsupported or unimplemented version number: " + version);
            }
            return ret;
        }

        public string AsHeaderStringVerbose(string separator, double version)
        {
            string ret = null;
            if (version > 3.0 && version < 4.0)
            {
                ret = AsHeaderStringVerbose_V03_01(separator, version);
            }
            //PAYTON:V4.02
            else if (version >= 4.0 && version < 4.02)
            {
                ret = AsHeaderStringVerbose_V04_01(separator, version);
            }
            else if (version >= 4.02 && version < 4.03)
            {
                ret = AsHeaderStringVerbose_V04_02(separator, version);
            }
            else if (version >= 4.03 && version < 4.04)
            {
                ret = AsHeaderStringVerbose_V04_03(separator, version);
            }
            else if (Version >= 4.04 && Version != 4.3)
            {
                ret = AsHeaderStringVerbose_V04_04(separator, version);
            }
            else
            {
                throw new Exception("Unsupported or unimplemented version number: " + version);
            }
            return ret;
        }

        // removed:     censusYear
        // added:      FeatureMatchingResultType

        public string AsString_V04_01(string separator, double version)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(TransactionId).Append(separator); //0
            sb.Append(Version).Append(separator); //1
            sb.Append(QueryStatusCodeValue).Append(separator); //2
            sb.Append(Latitude).Append(separator); //3
            sb.Append(Longitude).Append(separator);  //4
            sb.Append(NAACCRGISCoordinateQualityCode).Append(separator);  //5
            sb.Append(NAACCRGISCoordinateQualityName).Append(separator); //6
            sb.Append(MatchScore).Append(separator); //7
            sb.Append(MatchType).Append(separator); //8
            sb.Append(FeatureMatchingResultType).Append(separator); //9
            sb.Append(FeatureMatchingResultCount).Append(separator); //9
            sb.Append(FeatureMatchingGeographyType).Append(separator); //10
            sb.Append(RegionSize).Append(separator); //11
            sb.Append(RegionSizeUnits).Append(separator); //12
            sb.Append(MatchedLocationType).Append(separator); //13
            sb.Append(TimeTaken).Append(separator); //14


            return sb.ToString();
        }

        public string AsString_V04_02(string separator, double version)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(TransactionId).Append(separator); //0
            sb.Append(Version).Append(separator); //1
            sb.Append(QueryStatusCodeValue).Append(separator); //2
            sb.Append(Latitude).Append(separator); //3
            sb.Append(Longitude).Append(separator);  //4
            sb.Append(NAACCRGISCoordinateQualityCode).Append(separator);  //5
            sb.Append(NAACCRGISCoordinateQualityName).Append(separator); //6
            sb.Append(MatchScore).Append(separator); //7
            sb.Append(MatchType).Append(separator); //8
            sb.Append(FeatureMatchingResultType).Append(separator); //9
            sb.Append(FeatureMatchingResultCount).Append(separator); //9
            sb.Append(FeatureMatchingGeographyType).Append(separator); //10
            sb.Append(RegionSize).Append(separator); //11
            sb.Append(RegionSizeUnits).Append(separator); //12
            sb.Append(MatchedLocationType).Append(separator); //13
            sb.Append(TimeTaken).Append(separator); //14
            //PAYTON:MicroMatchStatus for v4.03
            //sb.Append(MicroMatchStatus).Append(separator); //15


            return sb.ToString();
        }

        public string AsString_V04_03(string separator, double version)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(TransactionId).Append(separator); //0
            sb.Append(Version).Append(separator); //1
            sb.Append(QueryStatusCodeValue).Append(separator); //2
            sb.Append(Latitude).Append(separator); //3
            sb.Append(Longitude).Append(separator);  //4
            sb.Append(NAACCRGISCoordinateQualityCode).Append(separator);  //5
            sb.Append(NAACCRGISCoordinateQualityName).Append(separator); //6
            sb.Append(MatchScore).Append(separator); //7
            sb.Append(MatchType).Append(separator); //8
            sb.Append(FeatureMatchingResultType).Append(separator); //9
            sb.Append(FeatureMatchingResultCount).Append(separator); //9
            sb.Append(FeatureMatchingGeographyType).Append(separator); //10
            sb.Append(RegionSize).Append(separator); //11
            sb.Append(RegionSizeUnits).Append(separator); //12
            sb.Append(MatchedLocationType).Append(separator); //13
            sb.Append(TimeTaken).Append(separator); //14
            //PAYTON:MicroMatchStatus for v4.03
            sb.Append(MicroMatchStatus).Append(separator); //15


            return sb.ToString();
        }

        public string AsString_V04_04(string separator, double version)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(TransactionId).Append(separator); //0
            sb.Append(Version).Append(separator); //1
            sb.Append(QueryStatusCodeValue).Append(separator); //2
            sb.Append(Latitude).Append(separator); //3
            sb.Append(Longitude).Append(separator);  //4
            sb.Append(NAACCRGISCoordinateQualityCode).Append(separator);  //5
            sb.Append(NAACCRGISCoordinateQualityName).Append(separator); //6
            sb.Append(MatchScore).Append(separator); //7
            sb.Append(MatchType).Append(separator); //8
            sb.Append(FeatureMatchingResultType).Append(separator); //9
            sb.Append(FeatureMatchingResultCount).Append(separator); //9
            sb.Append(FeatureMatchingGeographyType).Append(separator); //10
            sb.Append(RegionSize).Append(separator); //11
            sb.Append(RegionSizeUnits).Append(separator); //12
            sb.Append(MatchedLocationType).Append(separator); //13
            sb.Append(TimeTaken).Append(separator); //14
            //PAYTON:MicroMatchStatus for v4.03
            sb.Append(MicroMatchStatus).Append(separator); //15
            //PAYTON:PENALTYCODE
            sb.Append(PenaltyCode).Append(separator); //16


            return sb.ToString();
        }

        public static string AsHeaderString_V04_01(string separator, double version)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("TransactionId").Append(separator); //0
            sb.Append("Version").Append(separator); //1
            sb.Append("QueryStatusCodeValue").Append(separator); //2
            sb.Append("Latitude").Append(separator); //3
            sb.Append("Longitude").Append(separator);  //4
            sb.Append("NAACCRGISCoordinateQualityCode").Append(separator);  //5
            sb.Append("NAACCRGISCoordinateQualityName").Append(separator); //6
            sb.Append("MatchScore").Append(separator); //7
            sb.Append("MatchType").Append(separator); //8
            sb.Append("FeatureMatchingResultType").Append(separator); //9
            sb.Append("FeatureMatchingResultCount").Append(separator); //9
            sb.Append("FeatureMatchingGeographyType").Append(separator); //10
            sb.Append("RegionSize").Append(separator); //11
            sb.Append("RegionSizeUnits").Append(separator); //12
            sb.Append("MatchedLocationType").Append(separator); //13
            sb.Append("TimeTaken").Append(separator); //14

            return sb.ToString();
        }

        public static string AsHeaderString_V04_02(string separator, double version)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("TransactionId").Append(separator); //0
            sb.Append("Version").Append(separator); //1
            sb.Append("QueryStatusCodeValue").Append(separator); //2
            sb.Append("Latitude").Append(separator); //3
            sb.Append("Longitude").Append(separator);  //4
            sb.Append("NAACCRGISCoordinateQualityCode").Append(separator);  //5
            sb.Append("NAACCRGISCoordinateQualityName").Append(separator); //6
            sb.Append("MatchScore").Append(separator); //7
            sb.Append("MatchType").Append(separator); //8
            sb.Append("FeatureMatchingResultType").Append(separator); //9
            sb.Append("FeatureMatchingResultCount").Append(separator); //9
            sb.Append("FeatureMatchingGeographyType").Append(separator); //10
            sb.Append("RegionSize").Append(separator); //11
            sb.Append("RegionSizeUnits").Append(separator); //12
            sb.Append("MatchedLocationType").Append(separator); //13
            sb.Append("TimeTaken").Append(separator); //14
            //PAYTON:MicroMatchStatus for v4.03
            //sb.Append("MicroMatchStatus").Append(separator); //15

            return sb.ToString();
        }

        public static string AsHeaderString_V04_03(string separator, double version)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("TransactionId").Append(separator); //0
            sb.Append("Version").Append(separator); //1
            sb.Append("QueryStatusCodeValue").Append(separator); //2
            sb.Append("Latitude").Append(separator); //3
            sb.Append("Longitude").Append(separator);  //4
            sb.Append("NAACCRGISCoordinateQualityCode").Append(separator);  //5
            sb.Append("NAACCRGISCoordinateQualityName").Append(separator); //6
            sb.Append("MatchScore").Append(separator); //7
            sb.Append("MatchType").Append(separator); //8
            sb.Append("FeatureMatchingResultType").Append(separator); //9
            sb.Append("FeatureMatchingResultCount").Append(separator); //9
            sb.Append("FeatureMatchingGeographyType").Append(separator); //10
            sb.Append("RegionSize").Append(separator); //11
            sb.Append("RegionSizeUnits").Append(separator); //12
            sb.Append("MatchedLocationType").Append(separator); //13
            sb.Append("TimeTaken").Append(separator); //14
            //PAYTON:MicroMatchStatus
            sb.Append("MicroMatchStatus").Append(separator); //15

            return sb.ToString();
        }

        public static string AsHeaderString_V04_04(string separator, double version)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("TransactionId").Append(separator); //0
            sb.Append("Version").Append(separator); //1
            sb.Append("QueryStatusCodeValue").Append(separator); //2
            sb.Append("Latitude").Append(separator); //3
            sb.Append("Longitude").Append(separator);  //4
            sb.Append("NAACCRGISCoordinateQualityCode").Append(separator);  //5
            sb.Append("NAACCRGISCoordinateQualityName").Append(separator); //6
            sb.Append("MatchScore").Append(separator); //7
            sb.Append("MatchType").Append(separator); //8
            sb.Append("FeatureMatchingResultType").Append(separator); //9
            sb.Append("FeatureMatchingResultCount").Append(separator); //9
            sb.Append("FeatureMatchingGeographyType").Append(separator); //10
            sb.Append("RegionSize").Append(separator); //11
            sb.Append("RegionSizeUnits").Append(separator); //12
            sb.Append("MatchedLocationType").Append(separator); //13
            sb.Append("TimeTaken").Append(separator); //14
            //PAYTON:MicroMatchStatus
            sb.Append("MicroMatchStatus").Append(separator); //15
            //PAYTON:PENALTYCODE
            sb.Append("PenaltyCode").Append(separator); //15

            return sb.ToString();
        }

        public string AsStringWithCensus_V04_01(string separator, double version)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(TransactionId).Append(separator); //0
            sb.Append(Version).Append(separator); //1
            sb.Append(QueryStatusCodeValue).Append(separator); //2
            sb.Append(Latitude).Append(separator); //3
            sb.Append(Longitude).Append(separator);  //4
            sb.Append(NAACCRGISCoordinateQualityCode).Append(separator);  //5
            sb.Append(NAACCRGISCoordinateQualityName).Append(separator); //6
            sb.Append(MatchScore).Append(separator); //7
            sb.Append(MatchType).Append(separator); //8
            sb.Append(FeatureMatchingResultType).Append(separator); //9
            sb.Append(FeatureMatchingResultCount).Append(separator); //9
            sb.Append(FeatureMatchingGeographyType).Append(separator); //10
            sb.Append(RegionSize).Append(separator); //11
            sb.Append(RegionSizeUnits).Append(separator); //12
            sb.Append(MatchedLocationType).Append(separator); //13
            sb.Append(TimeTaken).Append(separator); //14

            sb.Append(NAACCRCensusTractCertaintyCode).Append(separator); //15
            sb.Append(NAACCRCensusTractCertaintyName).Append(separator); //16

            if (CensusRecords != null)
            {
                //1990 - 17 - 27
                //2000 - 28 - 38
                //2010 - 39 - 49
                if (CensusRecords.Count == 3) // if there are three records, add them in a row
                {
                    foreach (CensusOutputRecord censusOutputRecord in CensusRecords)
                    {

                        sb.Append(censusOutputRecord.CensusBlock).Append(separator); //17
                        sb.Append(censusOutputRecord.CensusBlockGroup).Append(separator); //18
                        sb.Append(censusOutputRecord.CensusTract).Append(separator); //19
                        sb.Append(censusOutputRecord.CensusCountyFips).Append(separator); //20
                        sb.Append(censusOutputRecord.CensusCbsaFips).Append(separator); //21
                        sb.Append(censusOutputRecord.CensusCbsaMicro).Append(separator); //22
                        sb.Append(censusOutputRecord.CensusMcdFips).Append(separator); //23
                        sb.Append(censusOutputRecord.CensusMetDivFips).Append(separator); //24
                        sb.Append(censusOutputRecord.CensusMsaFips).Append(separator); //25
                        sb.Append(censusOutputRecord.CensusPlaceFips).Append(separator); //26
                        sb.Append(censusOutputRecord.CensusStateFips).Append(separator); //27

                    }
                }
                else // otherwise fill in the appropriate ones and blank out the rest
                {
                    StringBuilder sb1990 = new StringBuilder();
                    StringBuilder sb2000 = new StringBuilder();
                    StringBuilder sb2010 = new StringBuilder();

                    for (int i = 0; i < CensusRecords.Count; i++)
                    {
                        CensusOutputRecord censusOutputRecord = CensusRecords[i];
                        if (censusOutputRecord.CensusYear == Census.Core.Configurations.ServerConfigurations.CensusYear.NineteenNinety)
                        {
                            sb1990.Append(censusOutputRecord.CensusBlock).Append(separator); //17
                            sb1990.Append(censusOutputRecord.CensusBlockGroup).Append(separator); //18
                            sb1990.Append(censusOutputRecord.CensusTract).Append(separator); //19
                            sb1990.Append(censusOutputRecord.CensusCountyFips).Append(separator); //20
                            sb1990.Append(censusOutputRecord.CensusCbsaFips).Append(separator); //21
                            sb1990.Append(censusOutputRecord.CensusCbsaMicro).Append(separator); //22
                            sb1990.Append(censusOutputRecord.CensusMcdFips).Append(separator); //23
                            sb1990.Append(censusOutputRecord.CensusMetDivFips).Append(separator); //24
                            sb1990.Append(censusOutputRecord.CensusMsaFips).Append(separator); //25
                            sb1990.Append(censusOutputRecord.CensusPlaceFips).Append(separator); //26
                            sb1990.Append(censusOutputRecord.CensusStateFips).Append(separator); //27
                        }
                        else if (censusOutputRecord.CensusYear == Census.Core.Configurations.ServerConfigurations.CensusYear.TwoThousand)
                        {
                            sb2000.Append(censusOutputRecord.CensusBlock).Append(separator); //17
                            sb2000.Append(censusOutputRecord.CensusBlockGroup).Append(separator); //18
                            sb2000.Append(censusOutputRecord.CensusTract).Append(separator); //19
                            sb2000.Append(censusOutputRecord.CensusCountyFips).Append(separator); //20
                            sb2000.Append(censusOutputRecord.CensusCbsaFips).Append(separator); //21
                            sb2000.Append(censusOutputRecord.CensusCbsaMicro).Append(separator); //22
                            sb2000.Append(censusOutputRecord.CensusMcdFips).Append(separator); //23
                            sb2000.Append(censusOutputRecord.CensusMetDivFips).Append(separator); //24
                            sb2000.Append(censusOutputRecord.CensusMsaFips).Append(separator); //25
                            sb2000.Append(censusOutputRecord.CensusPlaceFips).Append(separator); //26
                            sb2000.Append(censusOutputRecord.CensusStateFips).Append(separator); //27
                        }
                        else if (censusOutputRecord.CensusYear == Census.Core.Configurations.ServerConfigurations.CensusYear.TwoThousandTen)
                        {
                            sb2010.Append(censusOutputRecord.CensusBlock).Append(separator); //17
                            sb2010.Append(censusOutputRecord.CensusBlockGroup).Append(separator); //18
                            sb2010.Append(censusOutputRecord.CensusTract).Append(separator); //19
                            sb2010.Append(censusOutputRecord.CensusCountyFips).Append(separator); //20
                            sb2010.Append(censusOutputRecord.CensusCbsaFips).Append(separator); //21
                            sb2010.Append(censusOutputRecord.CensusCbsaMicro).Append(separator); //22
                            sb2010.Append(censusOutputRecord.CensusMcdFips).Append(separator); //23
                            sb2010.Append(censusOutputRecord.CensusMetDivFips).Append(separator); //24
                            sb2010.Append(censusOutputRecord.CensusMsaFips).Append(separator); //25
                            sb2010.Append(censusOutputRecord.CensusPlaceFips).Append(separator); //26
                            sb2010.Append(censusOutputRecord.CensusStateFips).Append(separator); //27
                        }

                        if (sb1990.Length == 0)
                        {
                            sb1990.Append("").Append(separator); //17
                            sb1990.Append("").Append(separator); //18
                            sb1990.Append("").Append(separator); //19
                            sb1990.Append("").Append(separator); //20
                            sb1990.Append("").Append(separator); //21
                            sb1990.Append("").Append(separator); //22
                            sb1990.Append("").Append(separator); //23
                            sb1990.Append("").Append(separator); //24
                            sb1990.Append("").Append(separator); //25
                            sb1990.Append("").Append(separator); //26
                            sb1990.Append("").Append(separator); //27
                        }

                        if (sb2000.Length == 0)
                        {
                            sb2000.Append("").Append(separator); //17
                            sb2000.Append("").Append(separator); //18
                            sb2000.Append("").Append(separator); //19
                            sb2000.Append("").Append(separator); //20
                            sb2000.Append("").Append(separator); //21
                            sb2000.Append("").Append(separator); //22
                            sb2000.Append("").Append(separator); //23
                            sb2000.Append("").Append(separator); //24
                            sb2000.Append("").Append(separator); //25
                            sb2000.Append("").Append(separator); //26
                            sb2000.Append("").Append(separator); //27
                        }

                        if (sb2010.Length == 0)
                        {
                            sb2010.Append("").Append(separator); //17
                            sb2010.Append("").Append(separator); //18
                            sb2010.Append("").Append(separator); //19
                            sb2010.Append("").Append(separator); //20
                            sb2010.Append("").Append(separator); //21
                            sb2010.Append("").Append(separator); //22
                            sb2010.Append("").Append(separator); //23
                            sb2010.Append("").Append(separator); //24
                            sb2010.Append("").Append(separator); //25
                            sb2010.Append("").Append(separator); //26
                            sb2010.Append("").Append(separator); //27
                        }
                    }

                    sb.Append(sb1990);
                    sb.Append(sb2000);
                    sb.Append(sb2010);
                }
            }


            return sb.ToString();
        }

        public string AsStringWithCensus_V04_02(string separator, double version)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(TransactionId).Append(separator); //0
            sb.Append(Version).Append(separator); //1
            sb.Append(QueryStatusCodeValue).Append(separator); //2
            sb.Append(Latitude).Append(separator); //3
            sb.Append(Longitude).Append(separator);  //4
            sb.Append(NAACCRGISCoordinateQualityCode).Append(separator);  //5
            sb.Append(NAACCRGISCoordinateQualityName).Append(separator); //6
            sb.Append(MatchScore).Append(separator); //7
            sb.Append(MatchType).Append(separator); //8
            sb.Append(FeatureMatchingResultType).Append(separator); //9
            sb.Append(FeatureMatchingResultCount).Append(separator); //9
            sb.Append(FeatureMatchingGeographyType).Append(separator); //10
            sb.Append(RegionSize).Append(separator); //11
            sb.Append(RegionSizeUnits).Append(separator); //12
            sb.Append(MatchedLocationType).Append(separator); //13
            sb.Append(TimeTaken).Append(separator); //14            

            sb.Append(NAACCRCensusTractCertaintyCode).Append(separator); //15
            sb.Append(NAACCRCensusTractCertaintyName).Append(separator); //16
            

            if (CensusRecords != null)
            {
                //1990 - 17 - 27
                //2000 - 28 - 38
                //2010 - 39 - 49
                if (CensusRecords.Count == 3) // if there are three records, add them in a row
                {
                    foreach (CensusOutputRecord censusOutputRecord in CensusRecords)
                    {

                        sb.Append(censusOutputRecord.CensusBlock).Append(separator); //17
                        sb.Append(censusOutputRecord.CensusBlockGroup).Append(separator); //18
                        sb.Append(censusOutputRecord.CensusTract).Append(separator); //19
                        sb.Append(censusOutputRecord.CensusCountyFips).Append(separator); //20
                        sb.Append(censusOutputRecord.CensusCbsaFips).Append(separator); //21
                        sb.Append(censusOutputRecord.CensusCbsaMicro).Append(separator); //22
                        sb.Append(censusOutputRecord.CensusMcdFips).Append(separator); //23
                        sb.Append(censusOutputRecord.CensusMetDivFips).Append(separator); //24
                        sb.Append(censusOutputRecord.CensusMsaFips).Append(separator); //25
                        sb.Append(censusOutputRecord.CensusPlaceFips).Append(separator); //26
                        sb.Append(censusOutputRecord.CensusStateFips).Append(separator); //27

                    }
                }
                else // otherwise fill in the appropriate ones and blank out the rest
                {
                    StringBuilder sb1990 = new StringBuilder();
                    StringBuilder sb2000 = new StringBuilder();
                    StringBuilder sb2010 = new StringBuilder();

                    for (int i = 0; i < CensusRecords.Count; i++)
                    {
                        CensusOutputRecord censusOutputRecord = CensusRecords[i];
                        if (censusOutputRecord.CensusYear == Census.Core.Configurations.ServerConfigurations.CensusYear.NineteenNinety)
                        {
                            sb1990.Append(censusOutputRecord.CensusBlock).Append(separator); //17
                            sb1990.Append(censusOutputRecord.CensusBlockGroup).Append(separator); //18
                            sb1990.Append(censusOutputRecord.CensusTract).Append(separator); //19
                            sb1990.Append(censusOutputRecord.CensusCountyFips).Append(separator); //20
                            sb1990.Append(censusOutputRecord.CensusCbsaFips).Append(separator); //21
                            sb1990.Append(censusOutputRecord.CensusCbsaMicro).Append(separator); //22
                            sb1990.Append(censusOutputRecord.CensusMcdFips).Append(separator); //23
                            sb1990.Append(censusOutputRecord.CensusMetDivFips).Append(separator); //24
                            sb1990.Append(censusOutputRecord.CensusMsaFips).Append(separator); //25
                            sb1990.Append(censusOutputRecord.CensusPlaceFips).Append(separator); //26
                            sb1990.Append(censusOutputRecord.CensusStateFips).Append(separator); //27
                        }
                        else if (censusOutputRecord.CensusYear == Census.Core.Configurations.ServerConfigurations.CensusYear.TwoThousand)
                        {
                            sb2000.Append(censusOutputRecord.CensusBlock).Append(separator); //17
                            sb2000.Append(censusOutputRecord.CensusBlockGroup).Append(separator); //18
                            sb2000.Append(censusOutputRecord.CensusTract).Append(separator); //19
                            sb2000.Append(censusOutputRecord.CensusCountyFips).Append(separator); //20
                            sb2000.Append(censusOutputRecord.CensusCbsaFips).Append(separator); //21
                            sb2000.Append(censusOutputRecord.CensusCbsaMicro).Append(separator); //22
                            sb2000.Append(censusOutputRecord.CensusMcdFips).Append(separator); //23
                            sb2000.Append(censusOutputRecord.CensusMetDivFips).Append(separator); //24
                            sb2000.Append(censusOutputRecord.CensusMsaFips).Append(separator); //25
                            sb2000.Append(censusOutputRecord.CensusPlaceFips).Append(separator); //26
                            sb2000.Append(censusOutputRecord.CensusStateFips).Append(separator); //27
                        }
                        else if (censusOutputRecord.CensusYear == Census.Core.Configurations.ServerConfigurations.CensusYear.TwoThousandTen)
                        {
                            sb2010.Append(censusOutputRecord.CensusBlock).Append(separator); //17
                            sb2010.Append(censusOutputRecord.CensusBlockGroup).Append(separator); //18
                            sb2010.Append(censusOutputRecord.CensusTract).Append(separator); //19
                            sb2010.Append(censusOutputRecord.CensusCountyFips).Append(separator); //20
                            sb2010.Append(censusOutputRecord.CensusCbsaFips).Append(separator); //21
                            sb2010.Append(censusOutputRecord.CensusCbsaMicro).Append(separator); //22
                            sb2010.Append(censusOutputRecord.CensusMcdFips).Append(separator); //23
                            sb2010.Append(censusOutputRecord.CensusMetDivFips).Append(separator); //24
                            sb2010.Append(censusOutputRecord.CensusMsaFips).Append(separator); //25
                            sb2010.Append(censusOutputRecord.CensusPlaceFips).Append(separator); //26
                            sb2010.Append(censusOutputRecord.CensusStateFips).Append(separator); //27
                        }

                        if (sb1990.Length == 0)
                        {
                            sb1990.Append("").Append(separator); //17
                            sb1990.Append("").Append(separator); //18
                            sb1990.Append("").Append(separator); //19
                            sb1990.Append("").Append(separator); //20
                            sb1990.Append("").Append(separator); //21
                            sb1990.Append("").Append(separator); //22
                            sb1990.Append("").Append(separator); //23
                            sb1990.Append("").Append(separator); //24
                            sb1990.Append("").Append(separator); //25
                            sb1990.Append("").Append(separator); //26
                            sb1990.Append("").Append(separator); //27
                        }

                        if (sb2000.Length == 0)
                        {
                            sb2000.Append("").Append(separator); //17
                            sb2000.Append("").Append(separator); //18
                            sb2000.Append("").Append(separator); //19
                            sb2000.Append("").Append(separator); //20
                            sb2000.Append("").Append(separator); //21
                            sb2000.Append("").Append(separator); //22
                            sb2000.Append("").Append(separator); //23
                            sb2000.Append("").Append(separator); //24
                            sb2000.Append("").Append(separator); //25
                            sb2000.Append("").Append(separator); //26
                            sb2000.Append("").Append(separator); //27
                        }

                        if (sb2010.Length == 0)
                        {
                            sb2010.Append("").Append(separator); //17
                            sb2010.Append("").Append(separator); //18
                            sb2010.Append("").Append(separator); //19
                            sb2010.Append("").Append(separator); //20
                            sb2010.Append("").Append(separator); //21
                            sb2010.Append("").Append(separator); //22
                            sb2010.Append("").Append(separator); //23
                            sb2010.Append("").Append(separator); //24
                            sb2010.Append("").Append(separator); //25
                            sb2010.Append("").Append(separator); //26
                            sb2010.Append("").Append(separator); //27
                        }
                    }

                    sb.Append(sb1990);
                    sb.Append(sb2000);
                    sb.Append(sb2010);
                }
            }
            //PAYTON:MicroMatchStatus - placing at end to mitigate any parsing issues for v4.03
            //sb.Append(MicroMatchStatus).Append(separator); //28

            return sb.ToString();
        }

        public string AsStringWithCensus_V04_03(string separator, double version)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(TransactionId).Append(separator); //0
            sb.Append(Version).Append(separator); //1
            sb.Append(QueryStatusCodeValue).Append(separator); //2
            sb.Append(Latitude).Append(separator); //3
            sb.Append(Longitude).Append(separator);  //4
            sb.Append(NAACCRGISCoordinateQualityCode).Append(separator);  //5
            sb.Append(NAACCRGISCoordinateQualityName).Append(separator); //6
            sb.Append(MatchScore).Append(separator); //7
            sb.Append(MatchType).Append(separator); //8
            sb.Append(FeatureMatchingResultType).Append(separator); //9
            sb.Append(FeatureMatchingResultCount).Append(separator); //9
            sb.Append(FeatureMatchingGeographyType).Append(separator); //10
            sb.Append(RegionSize).Append(separator); //11
            sb.Append(RegionSizeUnits).Append(separator); //12
            sb.Append(MatchedLocationType).Append(separator); //13
            sb.Append(TimeTaken).Append(separator); //14            

            sb.Append(NAACCRCensusTractCertaintyCode).Append(separator); //15
            sb.Append(NAACCRCensusTractCertaintyName).Append(separator); //16


            if (CensusRecords != null)
            {
                //1990 - 17 - 27
                //2000 - 28 - 38
                //2010 - 39 - 49
                if (CensusRecords.Count == 3) // if there are three records, add them in a row
                {
                    foreach (CensusOutputRecord censusOutputRecord in CensusRecords)
                    {

                        sb.Append(censusOutputRecord.CensusBlock).Append(separator); //17
                        sb.Append(censusOutputRecord.CensusBlockGroup).Append(separator); //18
                        sb.Append(censusOutputRecord.CensusTract).Append(separator); //19
                        sb.Append(censusOutputRecord.CensusCountyFips).Append(separator); //20
                        sb.Append(censusOutputRecord.CensusCbsaFips).Append(separator); //21
                        sb.Append(censusOutputRecord.CensusCbsaMicro).Append(separator); //22
                        sb.Append(censusOutputRecord.CensusMcdFips).Append(separator); //23
                        sb.Append(censusOutputRecord.CensusMetDivFips).Append(separator); //24
                        sb.Append(censusOutputRecord.CensusMsaFips).Append(separator); //25
                        sb.Append(censusOutputRecord.CensusPlaceFips).Append(separator); //26
                        sb.Append(censusOutputRecord.CensusStateFips).Append(separator); //27

                    }
                }
                else // otherwise fill in the appropriate ones and blank out the rest
                {
                    StringBuilder sb1990 = new StringBuilder();
                    StringBuilder sb2000 = new StringBuilder();
                    StringBuilder sb2010 = new StringBuilder();

                    for (int i = 0; i < CensusRecords.Count; i++)
                    {
                        CensusOutputRecord censusOutputRecord = CensusRecords[i];
                        if (censusOutputRecord.CensusYear == Census.Core.Configurations.ServerConfigurations.CensusYear.NineteenNinety)
                        {
                            sb1990.Append(censusOutputRecord.CensusBlock).Append(separator); //17
                            sb1990.Append(censusOutputRecord.CensusBlockGroup).Append(separator); //18
                            sb1990.Append(censusOutputRecord.CensusTract).Append(separator); //19
                            sb1990.Append(censusOutputRecord.CensusCountyFips).Append(separator); //20
                            sb1990.Append(censusOutputRecord.CensusCbsaFips).Append(separator); //21
                            sb1990.Append(censusOutputRecord.CensusCbsaMicro).Append(separator); //22
                            sb1990.Append(censusOutputRecord.CensusMcdFips).Append(separator); //23
                            sb1990.Append(censusOutputRecord.CensusMetDivFips).Append(separator); //24
                            sb1990.Append(censusOutputRecord.CensusMsaFips).Append(separator); //25
                            sb1990.Append(censusOutputRecord.CensusPlaceFips).Append(separator); //26
                            sb1990.Append(censusOutputRecord.CensusStateFips).Append(separator); //27
                        }
                        else if (censusOutputRecord.CensusYear == Census.Core.Configurations.ServerConfigurations.CensusYear.TwoThousand)
                        {
                            sb2000.Append(censusOutputRecord.CensusBlock).Append(separator); //17
                            sb2000.Append(censusOutputRecord.CensusBlockGroup).Append(separator); //18
                            sb2000.Append(censusOutputRecord.CensusTract).Append(separator); //19
                            sb2000.Append(censusOutputRecord.CensusCountyFips).Append(separator); //20
                            sb2000.Append(censusOutputRecord.CensusCbsaFips).Append(separator); //21
                            sb2000.Append(censusOutputRecord.CensusCbsaMicro).Append(separator); //22
                            sb2000.Append(censusOutputRecord.CensusMcdFips).Append(separator); //23
                            sb2000.Append(censusOutputRecord.CensusMetDivFips).Append(separator); //24
                            sb2000.Append(censusOutputRecord.CensusMsaFips).Append(separator); //25
                            sb2000.Append(censusOutputRecord.CensusPlaceFips).Append(separator); //26
                            sb2000.Append(censusOutputRecord.CensusStateFips).Append(separator); //27
                        }
                        else if (censusOutputRecord.CensusYear == Census.Core.Configurations.ServerConfigurations.CensusYear.TwoThousandTen)
                        {
                            sb2010.Append(censusOutputRecord.CensusBlock).Append(separator); //17
                            sb2010.Append(censusOutputRecord.CensusBlockGroup).Append(separator); //18
                            sb2010.Append(censusOutputRecord.CensusTract).Append(separator); //19
                            sb2010.Append(censusOutputRecord.CensusCountyFips).Append(separator); //20
                            sb2010.Append(censusOutputRecord.CensusCbsaFips).Append(separator); //21
                            sb2010.Append(censusOutputRecord.CensusCbsaMicro).Append(separator); //22
                            sb2010.Append(censusOutputRecord.CensusMcdFips).Append(separator); //23
                            sb2010.Append(censusOutputRecord.CensusMetDivFips).Append(separator); //24
                            sb2010.Append(censusOutputRecord.CensusMsaFips).Append(separator); //25
                            sb2010.Append(censusOutputRecord.CensusPlaceFips).Append(separator); //26
                            sb2010.Append(censusOutputRecord.CensusStateFips).Append(separator); //27
                        }

                        if (sb1990.Length == 0)
                        {
                            sb1990.Append("").Append(separator); //17
                            sb1990.Append("").Append(separator); //18
                            sb1990.Append("").Append(separator); //19
                            sb1990.Append("").Append(separator); //20
                            sb1990.Append("").Append(separator); //21
                            sb1990.Append("").Append(separator); //22
                            sb1990.Append("").Append(separator); //23
                            sb1990.Append("").Append(separator); //24
                            sb1990.Append("").Append(separator); //25
                            sb1990.Append("").Append(separator); //26
                            sb1990.Append("").Append(separator); //27
                        }

                        if (sb2000.Length == 0)
                        {
                            sb2000.Append("").Append(separator); //17
                            sb2000.Append("").Append(separator); //18
                            sb2000.Append("").Append(separator); //19
                            sb2000.Append("").Append(separator); //20
                            sb2000.Append("").Append(separator); //21
                            sb2000.Append("").Append(separator); //22
                            sb2000.Append("").Append(separator); //23
                            sb2000.Append("").Append(separator); //24
                            sb2000.Append("").Append(separator); //25
                            sb2000.Append("").Append(separator); //26
                            sb2000.Append("").Append(separator); //27
                        }

                        if (sb2010.Length == 0)
                        {
                            sb2010.Append("").Append(separator); //17
                            sb2010.Append("").Append(separator); //18
                            sb2010.Append("").Append(separator); //19
                            sb2010.Append("").Append(separator); //20
                            sb2010.Append("").Append(separator); //21
                            sb2010.Append("").Append(separator); //22
                            sb2010.Append("").Append(separator); //23
                            sb2010.Append("").Append(separator); //24
                            sb2010.Append("").Append(separator); //25
                            sb2010.Append("").Append(separator); //26
                            sb2010.Append("").Append(separator); //27
                        }
                    }

                    sb.Append(sb1990);
                    sb.Append(sb2000);
                    sb.Append(sb2010);
                }
            }
            //PAYTON:MicroMatchStatus - placing at end to mitigate any parsing issues for v4.03
            sb.Append(MicroMatchStatus).Append(separator); //28

            return sb.ToString();
        }

        public string AsStringWithCensus_V04_04(string separator, double version)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(TransactionId).Append(separator); //0
            sb.Append(Version).Append(separator); //1
            sb.Append(QueryStatusCodeValue).Append(separator); //2
            sb.Append(Latitude).Append(separator); //3
            sb.Append(Longitude).Append(separator);  //4
            sb.Append(NAACCRGISCoordinateQualityCode).Append(separator);  //5
            sb.Append(NAACCRGISCoordinateQualityName).Append(separator); //6
            sb.Append(MatchScore).Append(separator); //7
            sb.Append(MatchType).Append(separator); //8
            sb.Append(FeatureMatchingResultType).Append(separator); //9
            sb.Append(FeatureMatchingResultCount).Append(separator); //9
            sb.Append(FeatureMatchingGeographyType).Append(separator); //10
            sb.Append(RegionSize).Append(separator); //11
            sb.Append(RegionSizeUnits).Append(separator); //12
            sb.Append(MatchedLocationType).Append(separator); //13
            sb.Append(TimeTaken).Append(separator); //14            

            sb.Append(NAACCRCensusTractCertaintyCode).Append(separator); //15
            sb.Append(NAACCRCensusTractCertaintyName).Append(separator); //16


            if (CensusRecords != null)
            {
                //1990 - 17 - 27
                //2000 - 28 - 38
                //2010 - 39 - 49
                if (CensusRecords.Count == 3) // if there are three records, add them in a row
                {
                    foreach (CensusOutputRecord censusOutputRecord in CensusRecords)
                    {

                        sb.Append(censusOutputRecord.CensusBlock).Append(separator); //17
                        sb.Append(censusOutputRecord.CensusBlockGroup).Append(separator); //18
                        sb.Append(censusOutputRecord.CensusTract).Append(separator); //19
                        sb.Append(censusOutputRecord.CensusCountyFips).Append(separator); //20
                        sb.Append(censusOutputRecord.CensusCbsaFips).Append(separator); //21
                        sb.Append(censusOutputRecord.CensusCbsaMicro).Append(separator); //22
                        sb.Append(censusOutputRecord.CensusMcdFips).Append(separator); //23
                        sb.Append(censusOutputRecord.CensusMetDivFips).Append(separator); //24
                        sb.Append(censusOutputRecord.CensusMsaFips).Append(separator); //25
                        sb.Append(censusOutputRecord.CensusPlaceFips).Append(separator); //26
                        sb.Append(censusOutputRecord.CensusStateFips).Append(separator); //27

                    }
                }
                else // otherwise fill in the appropriate ones and blank out the rest
                {
                    StringBuilder sb1990 = new StringBuilder();
                    StringBuilder sb2000 = new StringBuilder();
                    StringBuilder sb2010 = new StringBuilder();

                    for (int i = 0; i < CensusRecords.Count; i++)
                    {
                        CensusOutputRecord censusOutputRecord = CensusRecords[i];
                        if (censusOutputRecord.CensusYear == Census.Core.Configurations.ServerConfigurations.CensusYear.NineteenNinety)
                        {
                            sb1990.Append(censusOutputRecord.CensusBlock).Append(separator); //17
                            sb1990.Append(censusOutputRecord.CensusBlockGroup).Append(separator); //18
                            sb1990.Append(censusOutputRecord.CensusTract).Append(separator); //19
                            sb1990.Append(censusOutputRecord.CensusCountyFips).Append(separator); //20
                            sb1990.Append(censusOutputRecord.CensusCbsaFips).Append(separator); //21
                            sb1990.Append(censusOutputRecord.CensusCbsaMicro).Append(separator); //22
                            sb1990.Append(censusOutputRecord.CensusMcdFips).Append(separator); //23
                            sb1990.Append(censusOutputRecord.CensusMetDivFips).Append(separator); //24
                            sb1990.Append(censusOutputRecord.CensusMsaFips).Append(separator); //25
                            sb1990.Append(censusOutputRecord.CensusPlaceFips).Append(separator); //26
                            sb1990.Append(censusOutputRecord.CensusStateFips).Append(separator); //27
                        }
                        else if (censusOutputRecord.CensusYear == Census.Core.Configurations.ServerConfigurations.CensusYear.TwoThousand)
                        {
                            sb2000.Append(censusOutputRecord.CensusBlock).Append(separator); //17
                            sb2000.Append(censusOutputRecord.CensusBlockGroup).Append(separator); //18
                            sb2000.Append(censusOutputRecord.CensusTract).Append(separator); //19
                            sb2000.Append(censusOutputRecord.CensusCountyFips).Append(separator); //20
                            sb2000.Append(censusOutputRecord.CensusCbsaFips).Append(separator); //21
                            sb2000.Append(censusOutputRecord.CensusCbsaMicro).Append(separator); //22
                            sb2000.Append(censusOutputRecord.CensusMcdFips).Append(separator); //23
                            sb2000.Append(censusOutputRecord.CensusMetDivFips).Append(separator); //24
                            sb2000.Append(censusOutputRecord.CensusMsaFips).Append(separator); //25
                            sb2000.Append(censusOutputRecord.CensusPlaceFips).Append(separator); //26
                            sb2000.Append(censusOutputRecord.CensusStateFips).Append(separator); //27
                        }
                        else if (censusOutputRecord.CensusYear == Census.Core.Configurations.ServerConfigurations.CensusYear.TwoThousandTen)
                        {
                            sb2010.Append(censusOutputRecord.CensusBlock).Append(separator); //17
                            sb2010.Append(censusOutputRecord.CensusBlockGroup).Append(separator); //18
                            sb2010.Append(censusOutputRecord.CensusTract).Append(separator); //19
                            sb2010.Append(censusOutputRecord.CensusCountyFips).Append(separator); //20
                            sb2010.Append(censusOutputRecord.CensusCbsaFips).Append(separator); //21
                            sb2010.Append(censusOutputRecord.CensusCbsaMicro).Append(separator); //22
                            sb2010.Append(censusOutputRecord.CensusMcdFips).Append(separator); //23
                            sb2010.Append(censusOutputRecord.CensusMetDivFips).Append(separator); //24
                            sb2010.Append(censusOutputRecord.CensusMsaFips).Append(separator); //25
                            sb2010.Append(censusOutputRecord.CensusPlaceFips).Append(separator); //26
                            sb2010.Append(censusOutputRecord.CensusStateFips).Append(separator); //27
                        }

                        if (sb1990.Length == 0)
                        {
                            sb1990.Append("").Append(separator); //17
                            sb1990.Append("").Append(separator); //18
                            sb1990.Append("").Append(separator); //19
                            sb1990.Append("").Append(separator); //20
                            sb1990.Append("").Append(separator); //21
                            sb1990.Append("").Append(separator); //22
                            sb1990.Append("").Append(separator); //23
                            sb1990.Append("").Append(separator); //24
                            sb1990.Append("").Append(separator); //25
                            sb1990.Append("").Append(separator); //26
                            sb1990.Append("").Append(separator); //27
                        }

                        if (sb2000.Length == 0)
                        {
                            sb2000.Append("").Append(separator); //17
                            sb2000.Append("").Append(separator); //18
                            sb2000.Append("").Append(separator); //19
                            sb2000.Append("").Append(separator); //20
                            sb2000.Append("").Append(separator); //21
                            sb2000.Append("").Append(separator); //22
                            sb2000.Append("").Append(separator); //23
                            sb2000.Append("").Append(separator); //24
                            sb2000.Append("").Append(separator); //25
                            sb2000.Append("").Append(separator); //26
                            sb2000.Append("").Append(separator); //27
                        }

                        if (sb2010.Length == 0)
                        {
                            sb2010.Append("").Append(separator); //17
                            sb2010.Append("").Append(separator); //18
                            sb2010.Append("").Append(separator); //19
                            sb2010.Append("").Append(separator); //20
                            sb2010.Append("").Append(separator); //21
                            sb2010.Append("").Append(separator); //22
                            sb2010.Append("").Append(separator); //23
                            sb2010.Append("").Append(separator); //24
                            sb2010.Append("").Append(separator); //25
                            sb2010.Append("").Append(separator); //26
                            sb2010.Append("").Append(separator); //27
                        }
                    }

                    sb.Append(sb1990);
                    sb.Append(sb2000);
                    sb.Append(sb2010);
                }
            }
            //PAYTON:MicroMatchStatus - placing at end to mitigate any parsing issues for v4.03
            sb.Append(MicroMatchStatus).Append(separator); //28
            //PAYTON:PENALTYCODE
            sb.Append(PenaltyCode).Append(separator); //29

            return sb.ToString();
        }

        public static string AsHeaderStringWithCensus_V04_01(string separator, double version)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("TransactionId").Append(separator); //0
            sb.Append("Version").Append(separator); //1
            sb.Append("QueryStatusCodeValue").Append(separator); //2
            sb.Append("Latitude").Append(separator); //3
            sb.Append("Longitude").Append(separator);  //4
            sb.Append("NAACCRGISCoordinateQualityCode").Append(separator);  //5
            sb.Append("NAACCRGISCoordinateQualityName").Append(separator); //6
            sb.Append("MatchScore").Append(separator); //7
            sb.Append("MatchType").Append(separator); //8
            sb.Append("FeatureMatchingResultType").Append(separator); //9
            sb.Append("FeatureMatchingResultCount").Append(separator); //9
            sb.Append("FeatureMatchingGeographyType").Append(separator); //10
            sb.Append("RegionSize").Append(separator); //11
            sb.Append("RegionSizeUnits").Append(separator); //12
            sb.Append("MatchedLocationType").Append(separator); //13
            sb.Append("TimeTaken").Append(separator); //14

            sb.Append("NAACCRCensusTractCertaintyCode").Append(separator); //15
            sb.Append("NAACCRCensusTractCertaintyName").Append(separator); //16


            sb.Append("Census1990Block").Append(separator); //17
            sb.Append("Census1990BlockGroup").Append(separator); //18
            sb.Append("Census1990Tract").Append(separator); //19
            sb.Append("Census1990CountyFips").Append(separator); //20
            sb.Append("Census1990CbsaFips").Append(separator); //21
            sb.Append("Census1990CbsaMicro").Append(separator); //22
            sb.Append("Census1990McdFips").Append(separator); //23
            sb.Append("Census1990MetDivFips").Append(separator); //24
            sb.Append("Census1990MsaFips").Append(separator); //25
            sb.Append("Census1990PlaceFips").Append(separator); //26
            sb.Append("Census1990StateFips").Append(separator); //27

            sb.Append("Census2000Block").Append(separator); //28
            sb.Append("Census2000BlockGroup").Append(separator); //29
            sb.Append("Census2000Tract").Append(separator); //30
            sb.Append("Census2000CountyFips").Append(separator); //31
            sb.Append("Census2000CbsaFips").Append(separator); //32
            sb.Append("Census2000CbsaMicro").Append(separator); //33
            sb.Append("Census2000McdFips").Append(separator); //34
            sb.Append("Census2000MetDivFips").Append(separator); //35
            sb.Append("Census2000MsaFips").Append(separator); //36
            sb.Append("Census2000PlaceFips").Append(separator); //37
            sb.Append("Census2000StateFips").Append(separator); //38

            sb.Append("Census2010Block").Append(separator); //39
            sb.Append("Census2010BlockGroup").Append(separator); //40
            sb.Append("Census2010Tract").Append(separator); //41
            sb.Append("Census2010CountyFips").Append(separator); //42
            sb.Append("Census2010CbsaFips").Append(separator); //43
            sb.Append("Census2010CbsaMicro").Append(separator); //44
            sb.Append("Census2010McdFips").Append(separator); //45
            sb.Append("Census2010MetDivFips").Append(separator); //46
            sb.Append("Census2010MsaFips").Append(separator); //47
            sb.Append("Census2010PlaceFips").Append(separator); //48
            sb.Append("Census2010StateFips"); //49

            return sb.ToString();
        }

        public static string AsHeaderStringWithCensus_V04_02(string separator, double version)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("TransactionId").Append(separator); //0
            sb.Append("Version").Append(separator); //1
            sb.Append("QueryStatusCodeValue").Append(separator); //2
            sb.Append("Latitude").Append(separator); //3
            sb.Append("Longitude").Append(separator);  //4
            sb.Append("NAACCRGISCoordinateQualityCode").Append(separator);  //5
            sb.Append("NAACCRGISCoordinateQualityName").Append(separator); //6
            sb.Append("MatchScore").Append(separator); //7
            sb.Append("MatchType").Append(separator); //8
            sb.Append("FeatureMatchingResultType").Append(separator); //9
            sb.Append("FeatureMatchingResultCount").Append(separator); //9
            sb.Append("FeatureMatchingGeographyType").Append(separator); //10
            sb.Append("RegionSize").Append(separator); //11
            sb.Append("RegionSizeUnits").Append(separator); //12
            sb.Append("MatchedLocationType").Append(separator); //13
            sb.Append("TimeTaken").Append(separator); //14

            sb.Append("NAACCRCensusTractCertaintyCode").Append(separator); //15
            sb.Append("NAACCRCensusTractCertaintyName").Append(separator); //16


            sb.Append("Census1990Block").Append(separator); //17
            sb.Append("Census1990BlockGroup").Append(separator); //18
            sb.Append("Census1990Tract").Append(separator); //19
            sb.Append("Census1990CountyFips").Append(separator); //20
            sb.Append("Census1990CbsaFips").Append(separator); //21
            sb.Append("Census1990CbsaMicro").Append(separator); //22
            sb.Append("Census1990McdFips").Append(separator); //23
            sb.Append("Census1990MetDivFips").Append(separator); //24
            sb.Append("Census1990MsaFips").Append(separator); //25
            sb.Append("Census1990PlaceFips").Append(separator); //26
            sb.Append("Census1990StateFips").Append(separator); //27

            sb.Append("Census2000Block").Append(separator); //28
            sb.Append("Census2000BlockGroup").Append(separator); //29
            sb.Append("Census2000Tract").Append(separator); //30
            sb.Append("Census2000CountyFips").Append(separator); //31
            sb.Append("Census2000CbsaFips").Append(separator); //32
            sb.Append("Census2000CbsaMicro").Append(separator); //33
            sb.Append("Census2000McdFips").Append(separator); //34
            sb.Append("Census2000MetDivFips").Append(separator); //35
            sb.Append("Census2000MsaFips").Append(separator); //36
            sb.Append("Census2000PlaceFips").Append(separator); //37
            sb.Append("Census2000StateFips").Append(separator); //38

            sb.Append("Census2010Block").Append(separator); //39
            sb.Append("Census2010BlockGroup").Append(separator); //40
            sb.Append("Census2010Tract").Append(separator); //41
            sb.Append("Census2010CountyFips").Append(separator); //42
            sb.Append("Census2010CbsaFips").Append(separator); //43
            sb.Append("Census2010CbsaMicro").Append(separator); //44
            sb.Append("Census2010McdFips").Append(separator); //45
            sb.Append("Census2010MetDivFips").Append(separator); //46
            sb.Append("Census2010MsaFips").Append(separator); //47
            sb.Append("Census2010PlaceFips").Append(separator); //48
            sb.Append("Census2010StateFips").Append(separator); //49

            //PAYTON:MicroMatchStatus -- this is for v4.03
            //sb.Append("MicroMatchStatus"); //50
            return sb.ToString();
        }

        public static string AsHeaderStringWithCensus_V04_03(string separator, double version)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("TransactionId").Append(separator); //0
            sb.Append("Version").Append(separator); //1
            sb.Append("QueryStatusCodeValue").Append(separator); //2
            sb.Append("Latitude").Append(separator); //3
            sb.Append("Longitude").Append(separator);  //4
            sb.Append("NAACCRGISCoordinateQualityCode").Append(separator);  //5
            sb.Append("NAACCRGISCoordinateQualityName").Append(separator); //6
            sb.Append("MatchScore").Append(separator); //7
            sb.Append("MatchType").Append(separator); //8
            sb.Append("FeatureMatchingResultType").Append(separator); //9
            sb.Append("FeatureMatchingResultCount").Append(separator); //9
            sb.Append("FeatureMatchingGeographyType").Append(separator); //10
            sb.Append("RegionSize").Append(separator); //11
            sb.Append("RegionSizeUnits").Append(separator); //12
            sb.Append("MatchedLocationType").Append(separator); //13
            sb.Append("TimeTaken").Append(separator); //14

            sb.Append("NAACCRCensusTractCertaintyCode").Append(separator); //15
            sb.Append("NAACCRCensusTractCertaintyName").Append(separator); //16


            sb.Append("Census1990Block").Append(separator); //17
            sb.Append("Census1990BlockGroup").Append(separator); //18
            sb.Append("Census1990Tract").Append(separator); //19
            sb.Append("Census1990CountyFips").Append(separator); //20
            sb.Append("Census1990CbsaFips").Append(separator); //21
            sb.Append("Census1990CbsaMicro").Append(separator); //22
            sb.Append("Census1990McdFips").Append(separator); //23
            sb.Append("Census1990MetDivFips").Append(separator); //24
            sb.Append("Census1990MsaFips").Append(separator); //25
            sb.Append("Census1990PlaceFips").Append(separator); //26
            sb.Append("Census1990StateFips").Append(separator); //27

            sb.Append("Census2000Block").Append(separator); //28
            sb.Append("Census2000BlockGroup").Append(separator); //29
            sb.Append("Census2000Tract").Append(separator); //30
            sb.Append("Census2000CountyFips").Append(separator); //31
            sb.Append("Census2000CbsaFips").Append(separator); //32
            sb.Append("Census2000CbsaMicro").Append(separator); //33
            sb.Append("Census2000McdFips").Append(separator); //34
            sb.Append("Census2000MetDivFips").Append(separator); //35
            sb.Append("Census2000MsaFips").Append(separator); //36
            sb.Append("Census2000PlaceFips").Append(separator); //37
            sb.Append("Census2000StateFips").Append(separator); //38

            sb.Append("Census2010Block").Append(separator); //39
            sb.Append("Census2010BlockGroup").Append(separator); //40
            sb.Append("Census2010Tract").Append(separator); //41
            sb.Append("Census2010CountyFips").Append(separator); //42
            sb.Append("Census2010CbsaFips").Append(separator); //43
            sb.Append("Census2010CbsaMicro").Append(separator); //44
            sb.Append("Census2010McdFips").Append(separator); //45
            sb.Append("Census2010MetDivFips").Append(separator); //46
            sb.Append("Census2010MsaFips").Append(separator); //47
            sb.Append("Census2010PlaceFips").Append(separator); //48
            sb.Append("Census2010StateFips").Append(separator); //49

            //PAYTON:MicroMatchStatus -- this is for v4.03
            sb.Append("MicroMatchStatus"); //50
            return sb.ToString();
        }

        public static string AsHeaderStringWithCensus_V04_04(string separator, double version)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("TransactionId").Append(separator); //0
            sb.Append("Version").Append(separator); //1
            sb.Append("QueryStatusCodeValue").Append(separator); //2
            sb.Append("Latitude").Append(separator); //3
            sb.Append("Longitude").Append(separator);  //4
            sb.Append("NAACCRGISCoordinateQualityCode").Append(separator);  //5
            sb.Append("NAACCRGISCoordinateQualityName").Append(separator); //6
            sb.Append("MatchScore").Append(separator); //7
            sb.Append("MatchType").Append(separator); //8
            sb.Append("FeatureMatchingResultType").Append(separator); //9
            sb.Append("FeatureMatchingResultCount").Append(separator); //9
            sb.Append("FeatureMatchingGeographyType").Append(separator); //10
            sb.Append("RegionSize").Append(separator); //11
            sb.Append("RegionSizeUnits").Append(separator); //12
            sb.Append("MatchedLocationType").Append(separator); //13
            sb.Append("TimeTaken").Append(separator); //14

            sb.Append("NAACCRCensusTractCertaintyCode").Append(separator); //15
            sb.Append("NAACCRCensusTractCertaintyName").Append(separator); //16


            sb.Append("Census1990Block").Append(separator); //17
            sb.Append("Census1990BlockGroup").Append(separator); //18
            sb.Append("Census1990Tract").Append(separator); //19
            sb.Append("Census1990CountyFips").Append(separator); //20
            sb.Append("Census1990CbsaFips").Append(separator); //21
            sb.Append("Census1990CbsaMicro").Append(separator); //22
            sb.Append("Census1990McdFips").Append(separator); //23
            sb.Append("Census1990MetDivFips").Append(separator); //24
            sb.Append("Census1990MsaFips").Append(separator); //25
            sb.Append("Census1990PlaceFips").Append(separator); //26
            sb.Append("Census1990StateFips").Append(separator); //27

            sb.Append("Census2000Block").Append(separator); //28
            sb.Append("Census2000BlockGroup").Append(separator); //29
            sb.Append("Census2000Tract").Append(separator); //30
            sb.Append("Census2000CountyFips").Append(separator); //31
            sb.Append("Census2000CbsaFips").Append(separator); //32
            sb.Append("Census2000CbsaMicro").Append(separator); //33
            sb.Append("Census2000McdFips").Append(separator); //34
            sb.Append("Census2000MetDivFips").Append(separator); //35
            sb.Append("Census2000MsaFips").Append(separator); //36
            sb.Append("Census2000PlaceFips").Append(separator); //37
            sb.Append("Census2000StateFips").Append(separator); //38

            sb.Append("Census2010Block").Append(separator); //39
            sb.Append("Census2010BlockGroup").Append(separator); //40
            sb.Append("Census2010Tract").Append(separator); //41
            sb.Append("Census2010CountyFips").Append(separator); //42
            sb.Append("Census2010CbsaFips").Append(separator); //43
            sb.Append("Census2010CbsaMicro").Append(separator); //44
            sb.Append("Census2010McdFips").Append(separator); //45
            sb.Append("Census2010MetDivFips").Append(separator); //46
            sb.Append("Census2010MsaFips").Append(separator); //47
            sb.Append("Census2010PlaceFips").Append(separator); //48
            sb.Append("Census2010StateFips").Append(separator); //49

            //PAYTON:MicroMatchStatus -- this is for v4.03
            sb.Append("MicroMatchStatus"); //50           
            //PAYTON:PENALTYCODE
            sb.Append("PenaltyCode"); //51
            return sb.ToString();
        }
       
        // removed:     censusYear
        // added:      census1990, census2000, census2010 as distinct values

        public string AsStringVerbose_V04_01(string separator, double version)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(TransactionId).Append(separator); //0
            sb.Append(Version).Append(separator); //1
            sb.Append(QueryStatusCodeValue).Append(separator); //2
            sb.Append(Latitude).Append(separator); //3
            sb.Append(Longitude).Append(separator);  //4
            sb.Append(NAACCRGISCoordinateQualityCode).Append(separator);  //5
            sb.Append(NAACCRGISCoordinateQualityName).Append(separator); //6
            sb.Append(MatchScore).Append(separator); //7
            sb.Append(MatchType).Append(separator); //8
            sb.Append(FeatureMatchingGeographyType).Append(separator); //9
            sb.Append(RegionSize).Append(separator); //10
            sb.Append(RegionSizeUnits).Append(separator); //11
            sb.Append(InterpolationType).Append(separator); //12
            sb.Append(InterpolationSubType).Append(separator); //13
            sb.Append(MatchedLocationType).Append(separator); //14
            sb.Append(FeatureMatchingResultType).Append(separator); //15
            sb.Append(FeatureMatchingResultCount).Append(separator); //16
            sb.Append(FeatureMatchingResultTypeNotes).Append(separator); //17
            sb.Append(FeatureMatchingResultTypeTieBreakingNotes).Append(separator); //18
            sb.Append(TieHandlingStrategyType).Append(separator); //19
            sb.Append(FeatureMatchingSelectionMethod).Append(separator); //20
            sb.Append(FeatureMatchingSelectionMethodNotes).Append(separator); //21
            sb.Append(TimeTaken).Append(separator); //22

            sb.Append(MNumber).Append(separator); //37
            sb.Append(MNumberFractional).Append(separator); //38
            sb.Append(MPreDirectional).Append(separator); //39
            sb.Append(MPreQualifier).Append(separator); //40
            sb.Append(MPreType).Append(separator); //41
            sb.Append(MPreArticle).Append(separator); //42
            sb.Append(MName).Append(separator); //43
            sb.Append(MPostArticle).Append(separator); //44
            sb.Append(MPostQualifier).Append(separator); //45
            sb.Append(MSuffix).Append(separator); //46
            sb.Append(MPostDirectional).Append(separator); //47
            sb.Append(MSuiteType).Append(separator); //48
            sb.Append(MSuiteNumber).Append(separator); //49
            sb.Append(MPostOfficeBoxType).Append(separator); //50
            sb.Append(MPostOfficeBoxNumber).Append(separator); //51
            sb.Append(MCity).Append(separator); //52
            sb.Append(MConsolidatedCity).Append(separator); //53
            sb.Append(MMinorCivilDivision).Append(separator); //54
            sb.Append(MCountySubRegion).Append(separator); //55
            sb.Append(MCounty).Append(separator); //56
            sb.Append(MState).Append(separator); //57
            sb.Append(MZip).Append(separator); //58
            sb.Append(MZipPlus1).Append(separator); //59
            sb.Append(MZipPlus2).Append(separator); //60
            sb.Append(MZipPlus3).Append(separator); //61
            sb.Append(MZipPlus4).Append(separator); //62
            sb.Append(MZipPlus5).Append(separator); //63

            sb.Append(PNumber).Append(separator); //64
            sb.Append(PNumberFractional).Append(separator); //65
            sb.Append(PPreDirectional).Append(separator); //66
            sb.Append(PPreQualifier).Append(separator); //67
            sb.Append(PPreType).Append(separator); //68
            sb.Append(PPreArticle).Append(separator); //69
            sb.Append(PName).Append(separator); //70
            sb.Append(PPostArticle).Append(separator); //71
            sb.Append(PPostQualifier).Append(separator); //72
            sb.Append(PSuffix).Append(separator); //73
            sb.Append(PPostDirectional).Append(separator); //74
            sb.Append(PSuiteType).Append(separator); //75
            sb.Append(PSuiteNumber).Append(separator); //76
            sb.Append(PPostOfficeBoxType).Append(separator); //77
            sb.Append(PPostOfficeBoxNumber).Append(separator); //78
            sb.Append(PCity).Append(separator); //79
            sb.Append(PConsolidatedCity).Append(separator); //80
            sb.Append(PMinorCivilDivision).Append(separator); //81
            sb.Append(PCountySubRegion).Append(separator); //82
            sb.Append(PCounty).Append(separator); //83
            sb.Append(PState).Append(separator); //84
            sb.Append(PZip).Append(separator); //85
            sb.Append(PZipPlus1).Append(separator); //86
            sb.Append(PZipPlus2).Append(separator); //87
            sb.Append(PZipPlus3).Append(separator); //88
            sb.Append(PZipPlus4).Append(separator); //89
            sb.Append(PZipPlus5).Append(separator); //90

            sb.Append(FNumber).Append(separator); //91
            sb.Append(FNumberFractional).Append(separator); //92
            sb.Append(FPreDirectional).Append(separator); //93
            sb.Append(FPreQualifier).Append(separator); //94
            sb.Append(FPreType).Append(separator); //95
            sb.Append(FPreArticle).Append(separator); //96
            sb.Append(FName).Append(separator); //97
            sb.Append(FPostArticle).Append(separator); //98
            sb.Append(FPostQualifier).Append(separator); //99
            sb.Append(FSuffix).Append(separator); //100
            sb.Append(FPostDirectional).Append(separator); //101
            sb.Append(FSuiteType).Append(separator); //102
            sb.Append(FSuiteNumber).Append(separator); //103
            sb.Append(FPostOfficeBoxType).Append(separator); //104
            sb.Append(FPostOfficeBoxNumber).Append(separator); //105
            sb.Append(FCity).Append(separator); //106
            sb.Append(FConsolidatedCity).Append(separator); //107
            sb.Append(FMinorCivilDivision).Append(separator); //108
            sb.Append(FCountySubRegion).Append(separator); //109
            sb.Append(FCounty).Append(separator); //110
            sb.Append(FState).Append(separator); //111
            sb.Append(FZip).Append(separator); //112
            sb.Append(FZipPlus1).Append(separator); //113
            sb.Append(FZipPlus2).Append(separator); //114
            sb.Append(FZipPlus3).Append(separator); //115
            sb.Append(FZipPlus4).Append(separator); //116
            sb.Append(FZipPlus5).Append(separator); //117
            sb.Append(FArea).Append(separator); //118
            sb.Append(FAreaType).Append(separator); //119

            sb.Append(FGeometrySRID).Append(separator); //120
            if (String.Compare(separator, ",", true) == 0)
            {
                sb.Append(FGeometry.Replace(separator, ";")).Append(separator); //121
            }
            else
            {
                sb.Append(FGeometry).Append(separator); //121
            }

            sb.Append(FSource).Append(separator); //122
            sb.Append(FVintage).Append(separator); //123
            sb.Append(FPrimaryIdField).Append(separator); //124
            sb.Append(FPrimaryIdValue).Append(separator); //125
            sb.Append(FSecondaryIdField).Append(separator); //126
            sb.Append(FSecondaryIdValue).Append(separator); //127

            sb.Append(NAACCRCensusTractCertaintyCode).Append(separator); //24
            sb.Append(NAACCRCensusTractCertaintyName).Append(separator); //25

            if (CensusRecords != null)
            {
                //1990 - 17 - 27
                //2000 - 28 - 38
                //2010 - 39 - 49
                if (CensusRecords.Count == 3) // if there are three records, add them in a row
                {
                    foreach (CensusOutputRecord censusOutputRecord in CensusRecords)
                    {

                        sb.Append(censusOutputRecord.CensusBlock).Append(separator); //17
                        sb.Append(censusOutputRecord.CensusBlockGroup).Append(separator); //18
                        sb.Append(censusOutputRecord.CensusTract).Append(separator); //19
                        sb.Append(censusOutputRecord.CensusCountyFips).Append(separator); //20
                        sb.Append(censusOutputRecord.CensusCbsaFips).Append(separator); //21
                        sb.Append(censusOutputRecord.CensusCbsaMicro).Append(separator); //22
                        sb.Append(censusOutputRecord.CensusMcdFips).Append(separator); //23
                        sb.Append(censusOutputRecord.CensusMetDivFips).Append(separator); //24
                        sb.Append(censusOutputRecord.CensusMsaFips).Append(separator); //25
                        sb.Append(censusOutputRecord.CensusPlaceFips).Append(separator); //26
                        sb.Append(censusOutputRecord.CensusStateFips).Append(separator); //27

                    }
                }
                else // otherwise fill in the appropriate ones and blank out the rest
                {
                    StringBuilder sb1990 = new StringBuilder();
                    StringBuilder sb2000 = new StringBuilder();
                    StringBuilder sb2010 = new StringBuilder();

                    for (int i = 0; i < CensusRecords.Count; i++)
                    {
                        CensusOutputRecord censusOutputRecord = CensusRecords[i];
                        if (censusOutputRecord.CensusYear == Census.Core.Configurations.ServerConfigurations.CensusYear.NineteenNinety)
                        {
                            sb1990.Append(censusOutputRecord.CensusBlock).Append(separator); //17
                            sb1990.Append(censusOutputRecord.CensusBlockGroup).Append(separator); //18
                            sb1990.Append(censusOutputRecord.CensusTract).Append(separator); //19
                            sb1990.Append(censusOutputRecord.CensusCountyFips).Append(separator); //20
                            sb1990.Append(censusOutputRecord.CensusCbsaFips).Append(separator); //21
                            sb1990.Append(censusOutputRecord.CensusCbsaMicro).Append(separator); //22
                            sb1990.Append(censusOutputRecord.CensusMcdFips).Append(separator); //23
                            sb1990.Append(censusOutputRecord.CensusMetDivFips).Append(separator); //24
                            sb1990.Append(censusOutputRecord.CensusMsaFips).Append(separator); //25
                            sb1990.Append(censusOutputRecord.CensusPlaceFips).Append(separator); //26
                            sb1990.Append(censusOutputRecord.CensusStateFips).Append(separator); //27
                        }
                        else if (censusOutputRecord.CensusYear == Census.Core.Configurations.ServerConfigurations.CensusYear.TwoThousand)
                        {
                            sb2000.Append(censusOutputRecord.CensusBlock).Append(separator); //17
                            sb2000.Append(censusOutputRecord.CensusBlockGroup).Append(separator); //18
                            sb2000.Append(censusOutputRecord.CensusTract).Append(separator); //19
                            sb2000.Append(censusOutputRecord.CensusCountyFips).Append(separator); //20
                            sb2000.Append(censusOutputRecord.CensusCbsaFips).Append(separator); //21
                            sb2000.Append(censusOutputRecord.CensusCbsaMicro).Append(separator); //22
                            sb2000.Append(censusOutputRecord.CensusMcdFips).Append(separator); //23
                            sb2000.Append(censusOutputRecord.CensusMetDivFips).Append(separator); //24
                            sb2000.Append(censusOutputRecord.CensusMsaFips).Append(separator); //25
                            sb2000.Append(censusOutputRecord.CensusPlaceFips).Append(separator); //26
                            sb2000.Append(censusOutputRecord.CensusStateFips).Append(separator); //27
                        }
                        else if (censusOutputRecord.CensusYear == Census.Core.Configurations.ServerConfigurations.CensusYear.TwoThousandTen)
                        {
                            sb2010.Append(censusOutputRecord.CensusBlock).Append(separator); //17
                            sb2010.Append(censusOutputRecord.CensusBlockGroup).Append(separator); //18
                            sb2010.Append(censusOutputRecord.CensusTract).Append(separator); //19
                            sb2010.Append(censusOutputRecord.CensusCountyFips).Append(separator); //20
                            sb2010.Append(censusOutputRecord.CensusCbsaFips).Append(separator); //21
                            sb2010.Append(censusOutputRecord.CensusCbsaMicro).Append(separator); //22
                            sb2010.Append(censusOutputRecord.CensusMcdFips).Append(separator); //23
                            sb2010.Append(censusOutputRecord.CensusMetDivFips).Append(separator); //24
                            sb2010.Append(censusOutputRecord.CensusMsaFips).Append(separator); //25
                            sb2010.Append(censusOutputRecord.CensusPlaceFips).Append(separator); //26
                            sb2010.Append(censusOutputRecord.CensusStateFips).Append(separator); //27
                        }

                        if (sb1990.Length == 0)
                        {
                            sb1990.Append("").Append(separator); //17
                            sb1990.Append("").Append(separator); //18
                            sb1990.Append("").Append(separator); //19
                            sb1990.Append("").Append(separator); //20
                            sb1990.Append("").Append(separator); //21
                            sb1990.Append("").Append(separator); //22
                            sb1990.Append("").Append(separator); //23
                            sb1990.Append("").Append(separator); //24
                            sb1990.Append("").Append(separator); //25
                            sb1990.Append("").Append(separator); //26
                            sb1990.Append("").Append(separator); //27
                        }

                        if (sb2000.Length == 0)
                        {
                            sb2000.Append("").Append(separator); //17
                            sb2000.Append("").Append(separator); //18
                            sb2000.Append("").Append(separator); //19
                            sb2000.Append("").Append(separator); //20
                            sb2000.Append("").Append(separator); //21
                            sb2000.Append("").Append(separator); //22
                            sb2000.Append("").Append(separator); //23
                            sb2000.Append("").Append(separator); //24
                            sb2000.Append("").Append(separator); //25
                            sb2000.Append("").Append(separator); //26
                            sb2000.Append("").Append(separator); //27
                        }

                        if (sb2010.Length == 0)
                        {
                            sb2010.Append("").Append(separator); //17
                            sb2010.Append("").Append(separator); //18
                            sb2010.Append("").Append(separator); //19
                            sb2010.Append("").Append(separator); //20
                            sb2010.Append("").Append(separator); //21
                            sb2010.Append("").Append(separator); //22
                            sb2010.Append("").Append(separator); //23
                            sb2010.Append("").Append(separator); //24
                            sb2010.Append("").Append(separator); //25
                            sb2010.Append("").Append(separator); //26
                            sb2010.Append("").Append(separator); //27
                        }
                    }

                    sb.Append(sb1990);
                    sb.Append(sb2000);
                    sb.Append(sb2010);
                }
            }

            return sb.ToString();
        }

        public string AsStringVerbose_V04_02(string separator, double version)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(TransactionId).Append(separator); //0
            sb.Append(Version).Append(separator); //1
            sb.Append(QueryStatusCodeValue).Append(separator); //2
            sb.Append(Latitude).Append(separator); //3
            sb.Append(Longitude).Append(separator);  //4
            sb.Append(NAACCRGISCoordinateQualityCode).Append(separator);  //5
            sb.Append(NAACCRGISCoordinateQualityName).Append(separator); //6
            sb.Append(MatchScore).Append(separator); //7
            sb.Append(MatchType).Append(separator); //8
            sb.Append(FeatureMatchingGeographyType).Append(separator); //9
            sb.Append(RegionSize).Append(separator); //10
            sb.Append(RegionSizeUnits).Append(separator); //11
            sb.Append(InterpolationType).Append(separator); //12
            sb.Append(InterpolationSubType).Append(separator); //13
            sb.Append(MatchedLocationType).Append(separator); //14
            sb.Append(FeatureMatchingResultType).Append(separator); //15
            sb.Append(FeatureMatchingResultCount).Append(separator); //16
            sb.Append(FeatureMatchingResultTypeNotes).Append(separator); //17
            sb.Append(FeatureMatchingResultTypeTieBreakingNotes).Append(separator); //18
            sb.Append(TieHandlingStrategyType).Append(separator); //19
            sb.Append(FeatureMatchingSelectionMethod).Append(separator); //20
            sb.Append(FeatureMatchingSelectionMethodNotes).Append(separator); //21
            sb.Append(TimeTaken).Append(separator); //22

            sb.Append(MNumber).Append(separator); //37
            sb.Append(MNumberFractional).Append(separator); //38
            sb.Append(MPreDirectional).Append(separator); //39
            sb.Append(MPreQualifier).Append(separator); //40
            sb.Append(MPreType).Append(separator); //41
            sb.Append(MPreArticle).Append(separator); //42
            sb.Append(MName).Append(separator); //43
            sb.Append(MPostArticle).Append(separator); //44
            sb.Append(MPostQualifier).Append(separator); //45
            sb.Append(MSuffix).Append(separator); //46
            sb.Append(MPostDirectional).Append(separator); //47
            sb.Append(MSuiteType).Append(separator); //48
            sb.Append(MSuiteNumber).Append(separator); //49
            sb.Append(MPostOfficeBoxType).Append(separator); //50
            sb.Append(MPostOfficeBoxNumber).Append(separator); //51
            sb.Append(MCity).Append(separator); //52
            sb.Append(MConsolidatedCity).Append(separator); //53
            sb.Append(MMinorCivilDivision).Append(separator); //54
            sb.Append(MCountySubRegion).Append(separator); //55
            sb.Append(MCounty).Append(separator); //56
            sb.Append(MState).Append(separator); //57
            sb.Append(MZip).Append(separator); //58
            sb.Append(MZipPlus1).Append(separator); //59
            sb.Append(MZipPlus2).Append(separator); //60
            sb.Append(MZipPlus3).Append(separator); //61
            sb.Append(MZipPlus4).Append(separator); //62
            sb.Append(MZipPlus5).Append(separator); //63

            sb.Append(PNumber).Append(separator); //64
            sb.Append(PNumberFractional).Append(separator); //65
            sb.Append(PPreDirectional).Append(separator); //66
            sb.Append(PPreQualifier).Append(separator); //67
            sb.Append(PPreType).Append(separator); //68
            sb.Append(PPreArticle).Append(separator); //69
            sb.Append(PName).Append(separator); //70
            sb.Append(PPostArticle).Append(separator); //71
            sb.Append(PPostQualifier).Append(separator); //72
            sb.Append(PSuffix).Append(separator); //73
            sb.Append(PPostDirectional).Append(separator); //74
            sb.Append(PSuiteType).Append(separator); //75
            sb.Append(PSuiteNumber).Append(separator); //76
            sb.Append(PPostOfficeBoxType).Append(separator); //77
            sb.Append(PPostOfficeBoxNumber).Append(separator); //78
            sb.Append(PCity).Append(separator); //79
            sb.Append(PConsolidatedCity).Append(separator); //80
            sb.Append(PMinorCivilDivision).Append(separator); //81
            sb.Append(PCountySubRegion).Append(separator); //82
            sb.Append(PCounty).Append(separator); //83
            sb.Append(PState).Append(separator); //84
            sb.Append(PZip).Append(separator); //85
            sb.Append(PZipPlus1).Append(separator); //86
            sb.Append(PZipPlus2).Append(separator); //87
            sb.Append(PZipPlus3).Append(separator); //88
            sb.Append(PZipPlus4).Append(separator); //89
            sb.Append(PZipPlus5).Append(separator); //90

            sb.Append(FNumber).Append(separator); //91
            sb.Append(FNumberFractional).Append(separator); //92
            sb.Append(FPreDirectional).Append(separator); //93
            sb.Append(FPreQualifier).Append(separator); //94
            sb.Append(FPreType).Append(separator); //95
            sb.Append(FPreArticle).Append(separator); //96
            sb.Append(FName).Append(separator); //97
            sb.Append(FPostArticle).Append(separator); //98
            sb.Append(FPostQualifier).Append(separator); //99
            sb.Append(FSuffix).Append(separator); //100
            sb.Append(FPostDirectional).Append(separator); //101
            sb.Append(FSuiteType).Append(separator); //102
            sb.Append(FSuiteNumber).Append(separator); //103
            sb.Append(FPostOfficeBoxType).Append(separator); //104
            sb.Append(FPostOfficeBoxNumber).Append(separator); //105
            sb.Append(FCity).Append(separator); //106
            sb.Append(FConsolidatedCity).Append(separator); //107
            sb.Append(FMinorCivilDivision).Append(separator); //108
            sb.Append(FCountySubRegion).Append(separator); //109
            sb.Append(FCounty).Append(separator); //110
            sb.Append(FState).Append(separator); //111
            sb.Append(FZip).Append(separator); //112
            sb.Append(FZipPlus1).Append(separator); //113
            sb.Append(FZipPlus2).Append(separator); //114
            sb.Append(FZipPlus3).Append(separator); //115
            sb.Append(FZipPlus4).Append(separator); //116
            sb.Append(FZipPlus5).Append(separator); //117
            sb.Append(FArea).Append(separator); //118
            sb.Append(FAreaType).Append(separator); //119

            sb.Append(FGeometrySRID).Append(separator); //120
            if (String.Compare(separator, ",", true) == 0)
            {
                sb.Append(FGeometry.Replace(separator, ";")).Append(separator); //121
            }
            else
            {
                sb.Append(FGeometry).Append(separator); //121
            }

            sb.Append(FSource).Append(separator); //122
            sb.Append(FVintage).Append(separator); //123
            sb.Append(FPrimaryIdField).Append(separator); //124
            sb.Append(FPrimaryIdValue).Append(separator); //125
            sb.Append(FSecondaryIdField).Append(separator); //126
            sb.Append(FSecondaryIdValue).Append(separator); //127

            sb.Append(NAACCRCensusTractCertaintyCode).Append(separator); //24
            sb.Append(NAACCRCensusTractCertaintyName).Append(separator); //25

            if (CensusRecords != null)
            {
                //1990 - 17 - 27
                //2000 - 28 - 38
                //2010 - 39 - 49
                if (CensusRecords.Count == 3) // if there are three records, add them in a row
                {
                    foreach (CensusOutputRecord censusOutputRecord in CensusRecords)
                    {

                        sb.Append(censusOutputRecord.CensusBlock).Append(separator); //17
                        sb.Append(censusOutputRecord.CensusBlockGroup).Append(separator); //18
                        sb.Append(censusOutputRecord.CensusTract).Append(separator); //19
                        sb.Append(censusOutputRecord.CensusCountyFips).Append(separator); //20
                        sb.Append(censusOutputRecord.CensusCbsaFips).Append(separator); //21
                        sb.Append(censusOutputRecord.CensusCbsaMicro).Append(separator); //22
                        sb.Append(censusOutputRecord.CensusMcdFips).Append(separator); //23
                        sb.Append(censusOutputRecord.CensusMetDivFips).Append(separator); //24
                        sb.Append(censusOutputRecord.CensusMsaFips).Append(separator); //25
                        sb.Append(censusOutputRecord.CensusPlaceFips).Append(separator); //26
                        sb.Append(censusOutputRecord.CensusStateFips).Append(separator); //27

                    }
                }
                else // otherwise fill in the appropriate ones and blank out the rest
                {
                    StringBuilder sb1990 = new StringBuilder();
                    StringBuilder sb2000 = new StringBuilder();
                    StringBuilder sb2010 = new StringBuilder();

                    for (int i = 0; i < CensusRecords.Count; i++)
                    {
                        CensusOutputRecord censusOutputRecord = CensusRecords[i];
                        if (censusOutputRecord.CensusYear == Census.Core.Configurations.ServerConfigurations.CensusYear.NineteenNinety)
                        {
                            sb1990.Append(censusOutputRecord.CensusBlock).Append(separator); //17
                            sb1990.Append(censusOutputRecord.CensusBlockGroup).Append(separator); //18
                            sb1990.Append(censusOutputRecord.CensusTract).Append(separator); //19
                            sb1990.Append(censusOutputRecord.CensusCountyFips).Append(separator); //20
                            sb1990.Append(censusOutputRecord.CensusCbsaFips).Append(separator); //21
                            sb1990.Append(censusOutputRecord.CensusCbsaMicro).Append(separator); //22
                            sb1990.Append(censusOutputRecord.CensusMcdFips).Append(separator); //23
                            sb1990.Append(censusOutputRecord.CensusMetDivFips).Append(separator); //24
                            sb1990.Append(censusOutputRecord.CensusMsaFips).Append(separator); //25
                            sb1990.Append(censusOutputRecord.CensusPlaceFips).Append(separator); //26
                            sb1990.Append(censusOutputRecord.CensusStateFips).Append(separator); //27
                        }
                        else if (censusOutputRecord.CensusYear == Census.Core.Configurations.ServerConfigurations.CensusYear.TwoThousand)
                        {
                            sb2000.Append(censusOutputRecord.CensusBlock).Append(separator); //17
                            sb2000.Append(censusOutputRecord.CensusBlockGroup).Append(separator); //18
                            sb2000.Append(censusOutputRecord.CensusTract).Append(separator); //19
                            sb2000.Append(censusOutputRecord.CensusCountyFips).Append(separator); //20
                            sb2000.Append(censusOutputRecord.CensusCbsaFips).Append(separator); //21
                            sb2000.Append(censusOutputRecord.CensusCbsaMicro).Append(separator); //22
                            sb2000.Append(censusOutputRecord.CensusMcdFips).Append(separator); //23
                            sb2000.Append(censusOutputRecord.CensusMetDivFips).Append(separator); //24
                            sb2000.Append(censusOutputRecord.CensusMsaFips).Append(separator); //25
                            sb2000.Append(censusOutputRecord.CensusPlaceFips).Append(separator); //26
                            sb2000.Append(censusOutputRecord.CensusStateFips).Append(separator); //27
                        }
                        else if (censusOutputRecord.CensusYear == Census.Core.Configurations.ServerConfigurations.CensusYear.TwoThousandTen)
                        {
                            sb2010.Append(censusOutputRecord.CensusBlock).Append(separator); //17
                            sb2010.Append(censusOutputRecord.CensusBlockGroup).Append(separator); //18
                            sb2010.Append(censusOutputRecord.CensusTract).Append(separator); //19
                            sb2010.Append(censusOutputRecord.CensusCountyFips).Append(separator); //20
                            sb2010.Append(censusOutputRecord.CensusCbsaFips).Append(separator); //21
                            sb2010.Append(censusOutputRecord.CensusCbsaMicro).Append(separator); //22
                            sb2010.Append(censusOutputRecord.CensusMcdFips).Append(separator); //23
                            sb2010.Append(censusOutputRecord.CensusMetDivFips).Append(separator); //24
                            sb2010.Append(censusOutputRecord.CensusMsaFips).Append(separator); //25
                            sb2010.Append(censusOutputRecord.CensusPlaceFips).Append(separator); //26
                            sb2010.Append(censusOutputRecord.CensusStateFips).Append(separator); //27
                        }

                        if (sb1990.Length == 0)
                        {
                            sb1990.Append("").Append(separator); //17
                            sb1990.Append("").Append(separator); //18
                            sb1990.Append("").Append(separator); //19
                            sb1990.Append("").Append(separator); //20
                            sb1990.Append("").Append(separator); //21
                            sb1990.Append("").Append(separator); //22
                            sb1990.Append("").Append(separator); //23
                            sb1990.Append("").Append(separator); //24
                            sb1990.Append("").Append(separator); //25
                            sb1990.Append("").Append(separator); //26
                            sb1990.Append("").Append(separator); //27
                        }

                        if (sb2000.Length == 0)
                        {
                            sb2000.Append("").Append(separator); //17
                            sb2000.Append("").Append(separator); //18
                            sb2000.Append("").Append(separator); //19
                            sb2000.Append("").Append(separator); //20
                            sb2000.Append("").Append(separator); //21
                            sb2000.Append("").Append(separator); //22
                            sb2000.Append("").Append(separator); //23
                            sb2000.Append("").Append(separator); //24
                            sb2000.Append("").Append(separator); //25
                            sb2000.Append("").Append(separator); //26
                            sb2000.Append("").Append(separator); //27
                        }

                        if (sb2010.Length == 0)
                        {
                            sb2010.Append("").Append(separator); //17
                            sb2010.Append("").Append(separator); //18
                            sb2010.Append("").Append(separator); //19
                            sb2010.Append("").Append(separator); //20
                            sb2010.Append("").Append(separator); //21
                            sb2010.Append("").Append(separator); //22
                            sb2010.Append("").Append(separator); //23
                            sb2010.Append("").Append(separator); //24
                            sb2010.Append("").Append(separator); //25
                            sb2010.Append("").Append(separator); //26
                            sb2010.Append("").Append(separator); //27
                        }
                    }

                    sb.Append(sb1990);
                    sb.Append(sb2000);
                    sb.Append(sb2010);
                }
            }
            //PAYTON:MicroMatchStatus for v4.03
            //sb.Append("MicroMatchStatus").Append(separator); //28
            return sb.ToString();
        }

        public string AsStringVerbose_V04_03(string separator, double version)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(TransactionId).Append(separator); //0
            sb.Append(Version).Append(separator); //1
            sb.Append(QueryStatusCodeValue).Append(separator); //2
            sb.Append(Latitude).Append(separator); //3
            sb.Append(Longitude).Append(separator);  //4
            sb.Append(NAACCRGISCoordinateQualityCode).Append(separator);  //5
            sb.Append(NAACCRGISCoordinateQualityName).Append(separator); //6
            sb.Append(MatchScore).Append(separator); //7
            sb.Append(MatchType).Append(separator); //8
            sb.Append(FeatureMatchingGeographyType).Append(separator); //9
            sb.Append(RegionSize).Append(separator); //10
            sb.Append(RegionSizeUnits).Append(separator); //11
            sb.Append(InterpolationType).Append(separator); //12
            sb.Append(InterpolationSubType).Append(separator); //13
            sb.Append(MatchedLocationType).Append(separator); //14
            sb.Append(FeatureMatchingResultType).Append(separator); //15
            sb.Append(FeatureMatchingResultCount).Append(separator); //16
            sb.Append(FeatureMatchingResultTypeNotes).Append(separator); //17
            sb.Append(FeatureMatchingResultTypeTieBreakingNotes).Append(separator); //18
            sb.Append(TieHandlingStrategyType).Append(separator); //19
            sb.Append(FeatureMatchingSelectionMethod).Append(separator); //20
            sb.Append(FeatureMatchingSelectionMethodNotes).Append(separator); //21
            sb.Append(TimeTaken).Append(separator); //22

            sb.Append(MNumber).Append(separator); //37
            sb.Append(MNumberFractional).Append(separator); //38
            sb.Append(MPreDirectional).Append(separator); //39
            sb.Append(MPreQualifier).Append(separator); //40
            sb.Append(MPreType).Append(separator); //41
            sb.Append(MPreArticle).Append(separator); //42
            sb.Append(MName).Append(separator); //43
            sb.Append(MPostArticle).Append(separator); //44
            sb.Append(MPostQualifier).Append(separator); //45
            sb.Append(MSuffix).Append(separator); //46
            sb.Append(MPostDirectional).Append(separator); //47
            sb.Append(MSuiteType).Append(separator); //48
            sb.Append(MSuiteNumber).Append(separator); //49
            sb.Append(MPostOfficeBoxType).Append(separator); //50
            sb.Append(MPostOfficeBoxNumber).Append(separator); //51
            sb.Append(MCity).Append(separator); //52
            sb.Append(MConsolidatedCity).Append(separator); //53
            sb.Append(MMinorCivilDivision).Append(separator); //54
            sb.Append(MCountySubRegion).Append(separator); //55
            sb.Append(MCounty).Append(separator); //56
            sb.Append(MState).Append(separator); //57
            sb.Append(MZip).Append(separator); //58
            sb.Append(MZipPlus1).Append(separator); //59
            sb.Append(MZipPlus2).Append(separator); //60
            sb.Append(MZipPlus3).Append(separator); //61
            sb.Append(MZipPlus4).Append(separator); //62
            sb.Append(MZipPlus5).Append(separator); //63

            sb.Append(PNumber).Append(separator); //64
            sb.Append(PNumberFractional).Append(separator); //65
            sb.Append(PPreDirectional).Append(separator); //66
            sb.Append(PPreQualifier).Append(separator); //67
            sb.Append(PPreType).Append(separator); //68
            sb.Append(PPreArticle).Append(separator); //69
            sb.Append(PName).Append(separator); //70
            sb.Append(PPostArticle).Append(separator); //71
            sb.Append(PPostQualifier).Append(separator); //72
            sb.Append(PSuffix).Append(separator); //73
            sb.Append(PPostDirectional).Append(separator); //74
            sb.Append(PSuiteType).Append(separator); //75
            sb.Append(PSuiteNumber).Append(separator); //76
            sb.Append(PPostOfficeBoxType).Append(separator); //77
            sb.Append(PPostOfficeBoxNumber).Append(separator); //78
            sb.Append(PCity).Append(separator); //79
            sb.Append(PConsolidatedCity).Append(separator); //80
            sb.Append(PMinorCivilDivision).Append(separator); //81
            sb.Append(PCountySubRegion).Append(separator); //82
            sb.Append(PCounty).Append(separator); //83
            sb.Append(PState).Append(separator); //84
            sb.Append(PZip).Append(separator); //85
            sb.Append(PZipPlus1).Append(separator); //86
            sb.Append(PZipPlus2).Append(separator); //87
            sb.Append(PZipPlus3).Append(separator); //88
            sb.Append(PZipPlus4).Append(separator); //89
            sb.Append(PZipPlus5).Append(separator); //90

            sb.Append(FNumber).Append(separator); //91
            sb.Append(FNumberFractional).Append(separator); //92
            sb.Append(FPreDirectional).Append(separator); //93
            sb.Append(FPreQualifier).Append(separator); //94
            sb.Append(FPreType).Append(separator); //95
            sb.Append(FPreArticle).Append(separator); //96
            sb.Append(FName).Append(separator); //97
            sb.Append(FPostArticle).Append(separator); //98
            sb.Append(FPostQualifier).Append(separator); //99
            sb.Append(FSuffix).Append(separator); //100
            sb.Append(FPostDirectional).Append(separator); //101
            sb.Append(FSuiteType).Append(separator); //102
            sb.Append(FSuiteNumber).Append(separator); //103
            sb.Append(FPostOfficeBoxType).Append(separator); //104
            sb.Append(FPostOfficeBoxNumber).Append(separator); //105
            sb.Append(FCity).Append(separator); //106
            sb.Append(FConsolidatedCity).Append(separator); //107
            sb.Append(FMinorCivilDivision).Append(separator); //108
            sb.Append(FCountySubRegion).Append(separator); //109
            sb.Append(FCounty).Append(separator); //110
            sb.Append(FState).Append(separator); //111
            sb.Append(FZip).Append(separator); //112
            sb.Append(FZipPlus1).Append(separator); //113
            sb.Append(FZipPlus2).Append(separator); //114
            sb.Append(FZipPlus3).Append(separator); //115
            sb.Append(FZipPlus4).Append(separator); //116
            sb.Append(FZipPlus5).Append(separator); //117
            sb.Append(FArea).Append(separator); //118
            sb.Append(FAreaType).Append(separator); //119

            sb.Append(FGeometrySRID).Append(separator); //120
            if (String.Compare(separator, ",", true) == 0)
            {
                sb.Append(FGeometry.Replace(separator, ";")).Append(separator); //121
            }
            else
            {
                sb.Append(FGeometry).Append(separator); //121
            }

            sb.Append(FSource).Append(separator); //122
            sb.Append(FVintage).Append(separator); //123
            sb.Append(FPrimaryIdField).Append(separator); //124
            sb.Append(FPrimaryIdValue).Append(separator); //125
            sb.Append(FSecondaryIdField).Append(separator); //126
            sb.Append(FSecondaryIdValue).Append(separator); //127

            sb.Append(NAACCRCensusTractCertaintyCode).Append(separator); //24
            sb.Append(NAACCRCensusTractCertaintyName).Append(separator); //25

            if (CensusRecords != null)
            {
                //1990 - 17 - 27
                //2000 - 28 - 38
                //2010 - 39 - 49
                if (CensusRecords.Count == 3) // if there are three records, add them in a row
                {
                    foreach (CensusOutputRecord censusOutputRecord in CensusRecords)
                    {

                        sb.Append(censusOutputRecord.CensusBlock).Append(separator); //17
                        sb.Append(censusOutputRecord.CensusBlockGroup).Append(separator); //18
                        sb.Append(censusOutputRecord.CensusTract).Append(separator); //19
                        sb.Append(censusOutputRecord.CensusCountyFips).Append(separator); //20
                        sb.Append(censusOutputRecord.CensusCbsaFips).Append(separator); //21
                        sb.Append(censusOutputRecord.CensusCbsaMicro).Append(separator); //22
                        sb.Append(censusOutputRecord.CensusMcdFips).Append(separator); //23
                        sb.Append(censusOutputRecord.CensusMetDivFips).Append(separator); //24
                        sb.Append(censusOutputRecord.CensusMsaFips).Append(separator); //25
                        sb.Append(censusOutputRecord.CensusPlaceFips).Append(separator); //26
                        sb.Append(censusOutputRecord.CensusStateFips).Append(separator); //27

                    }
                }
                else // otherwise fill in the appropriate ones and blank out the rest
                {
                    StringBuilder sb1990 = new StringBuilder();
                    StringBuilder sb2000 = new StringBuilder();
                    StringBuilder sb2010 = new StringBuilder();

                    for (int i = 0; i < CensusRecords.Count; i++)
                    {
                        CensusOutputRecord censusOutputRecord = CensusRecords[i];
                        if (censusOutputRecord.CensusYear == Census.Core.Configurations.ServerConfigurations.CensusYear.NineteenNinety)
                        {
                            sb1990.Append(censusOutputRecord.CensusBlock).Append(separator); //17
                            sb1990.Append(censusOutputRecord.CensusBlockGroup).Append(separator); //18
                            sb1990.Append(censusOutputRecord.CensusTract).Append(separator); //19
                            sb1990.Append(censusOutputRecord.CensusCountyFips).Append(separator); //20
                            sb1990.Append(censusOutputRecord.CensusCbsaFips).Append(separator); //21
                            sb1990.Append(censusOutputRecord.CensusCbsaMicro).Append(separator); //22
                            sb1990.Append(censusOutputRecord.CensusMcdFips).Append(separator); //23
                            sb1990.Append(censusOutputRecord.CensusMetDivFips).Append(separator); //24
                            sb1990.Append(censusOutputRecord.CensusMsaFips).Append(separator); //25
                            sb1990.Append(censusOutputRecord.CensusPlaceFips).Append(separator); //26
                            sb1990.Append(censusOutputRecord.CensusStateFips).Append(separator); //27
                        }
                        else if (censusOutputRecord.CensusYear == Census.Core.Configurations.ServerConfigurations.CensusYear.TwoThousand)
                        {
                            sb2000.Append(censusOutputRecord.CensusBlock).Append(separator); //17
                            sb2000.Append(censusOutputRecord.CensusBlockGroup).Append(separator); //18
                            sb2000.Append(censusOutputRecord.CensusTract).Append(separator); //19
                            sb2000.Append(censusOutputRecord.CensusCountyFips).Append(separator); //20
                            sb2000.Append(censusOutputRecord.CensusCbsaFips).Append(separator); //21
                            sb2000.Append(censusOutputRecord.CensusCbsaMicro).Append(separator); //22
                            sb2000.Append(censusOutputRecord.CensusMcdFips).Append(separator); //23
                            sb2000.Append(censusOutputRecord.CensusMetDivFips).Append(separator); //24
                            sb2000.Append(censusOutputRecord.CensusMsaFips).Append(separator); //25
                            sb2000.Append(censusOutputRecord.CensusPlaceFips).Append(separator); //26
                            sb2000.Append(censusOutputRecord.CensusStateFips).Append(separator); //27
                        }
                        else if (censusOutputRecord.CensusYear == Census.Core.Configurations.ServerConfigurations.CensusYear.TwoThousandTen)
                        {
                            sb2010.Append(censusOutputRecord.CensusBlock).Append(separator); //17
                            sb2010.Append(censusOutputRecord.CensusBlockGroup).Append(separator); //18
                            sb2010.Append(censusOutputRecord.CensusTract).Append(separator); //19
                            sb2010.Append(censusOutputRecord.CensusCountyFips).Append(separator); //20
                            sb2010.Append(censusOutputRecord.CensusCbsaFips).Append(separator); //21
                            sb2010.Append(censusOutputRecord.CensusCbsaMicro).Append(separator); //22
                            sb2010.Append(censusOutputRecord.CensusMcdFips).Append(separator); //23
                            sb2010.Append(censusOutputRecord.CensusMetDivFips).Append(separator); //24
                            sb2010.Append(censusOutputRecord.CensusMsaFips).Append(separator); //25
                            sb2010.Append(censusOutputRecord.CensusPlaceFips).Append(separator); //26
                            sb2010.Append(censusOutputRecord.CensusStateFips).Append(separator); //27
                        }

                        if (sb1990.Length == 0)
                        {
                            sb1990.Append("").Append(separator); //17
                            sb1990.Append("").Append(separator); //18
                            sb1990.Append("").Append(separator); //19
                            sb1990.Append("").Append(separator); //20
                            sb1990.Append("").Append(separator); //21
                            sb1990.Append("").Append(separator); //22
                            sb1990.Append("").Append(separator); //23
                            sb1990.Append("").Append(separator); //24
                            sb1990.Append("").Append(separator); //25
                            sb1990.Append("").Append(separator); //26
                            sb1990.Append("").Append(separator); //27
                        }

                        if (sb2000.Length == 0)
                        {
                            sb2000.Append("").Append(separator); //17
                            sb2000.Append("").Append(separator); //18
                            sb2000.Append("").Append(separator); //19
                            sb2000.Append("").Append(separator); //20
                            sb2000.Append("").Append(separator); //21
                            sb2000.Append("").Append(separator); //22
                            sb2000.Append("").Append(separator); //23
                            sb2000.Append("").Append(separator); //24
                            sb2000.Append("").Append(separator); //25
                            sb2000.Append("").Append(separator); //26
                            sb2000.Append("").Append(separator); //27
                        }

                        if (sb2010.Length == 0)
                        {
                            sb2010.Append("").Append(separator); //17
                            sb2010.Append("").Append(separator); //18
                            sb2010.Append("").Append(separator); //19
                            sb2010.Append("").Append(separator); //20
                            sb2010.Append("").Append(separator); //21
                            sb2010.Append("").Append(separator); //22
                            sb2010.Append("").Append(separator); //23
                            sb2010.Append("").Append(separator); //24
                            sb2010.Append("").Append(separator); //25
                            sb2010.Append("").Append(separator); //26
                            sb2010.Append("").Append(separator); //27
                        }
                    }

                    sb.Append(sb1990);
                    sb.Append(sb2000);
                    sb.Append(sb2010);
                }
            }
            //PAYTON:MicroMatchStatus for v4.03
            sb.Append(MicroMatchStatus).Append(separator); //28
            return sb.ToString();
        }

        public string AsStringVerbose_V04_04(string separator, double version)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(TransactionId).Append(separator); //0
            sb.Append(Version).Append(separator); //1
            sb.Append(QueryStatusCodeValue).Append(separator); //2
            sb.Append(Latitude).Append(separator); //3
            sb.Append(Longitude).Append(separator);  //4
            sb.Append(NAACCRGISCoordinateQualityCode).Append(separator);  //5
            sb.Append(NAACCRGISCoordinateQualityName).Append(separator); //6
            sb.Append(MatchScore).Append(separator); //7
            sb.Append(MatchType).Append(separator); //8
            sb.Append(FeatureMatchingGeographyType).Append(separator); //9
            sb.Append(RegionSize).Append(separator); //10
            sb.Append(RegionSizeUnits).Append(separator); //11
            sb.Append(InterpolationType).Append(separator); //12
            sb.Append(InterpolationSubType).Append(separator); //13
            sb.Append(MatchedLocationType).Append(separator); //14
            sb.Append(FeatureMatchingResultType).Append(separator); //15
            sb.Append(FeatureMatchingResultCount).Append(separator); //16
            sb.Append(FeatureMatchingResultTypeNotes).Append(separator); //17
            sb.Append(FeatureMatchingResultTypeTieBreakingNotes).Append(separator); //18
            sb.Append(TieHandlingStrategyType).Append(separator); //19
            sb.Append(FeatureMatchingSelectionMethod).Append(separator); //20
            sb.Append(FeatureMatchingSelectionMethodNotes).Append(separator); //21
            sb.Append(TimeTaken).Append(separator); //22

            sb.Append(MNumber).Append(separator); //37
            sb.Append(MNumberFractional).Append(separator); //38
            sb.Append(MPreDirectional).Append(separator); //39
            sb.Append(MPreQualifier).Append(separator); //40
            sb.Append(MPreType).Append(separator); //41
            sb.Append(MPreArticle).Append(separator); //42
            sb.Append(MName).Append(separator); //43
            sb.Append(MPostArticle).Append(separator); //44
            sb.Append(MPostQualifier).Append(separator); //45
            sb.Append(MSuffix).Append(separator); //46
            sb.Append(MPostDirectional).Append(separator); //47
            sb.Append(MSuiteType).Append(separator); //48
            sb.Append(MSuiteNumber).Append(separator); //49
            sb.Append(MPostOfficeBoxType).Append(separator); //50
            sb.Append(MPostOfficeBoxNumber).Append(separator); //51
            sb.Append(MCity).Append(separator); //52
            sb.Append(MConsolidatedCity).Append(separator); //53
            sb.Append(MMinorCivilDivision).Append(separator); //54
            sb.Append(MCountySubRegion).Append(separator); //55
            sb.Append(MCounty).Append(separator); //56
            sb.Append(MState).Append(separator); //57
            sb.Append(MZip).Append(separator); //58
            sb.Append(MZipPlus1).Append(separator); //59
            sb.Append(MZipPlus2).Append(separator); //60
            sb.Append(MZipPlus3).Append(separator); //61
            sb.Append(MZipPlus4).Append(separator); //62
            sb.Append(MZipPlus5).Append(separator); //63

            sb.Append(PNumber).Append(separator); //64
            sb.Append(PNumberFractional).Append(separator); //65
            sb.Append(PPreDirectional).Append(separator); //66
            sb.Append(PPreQualifier).Append(separator); //67
            sb.Append(PPreType).Append(separator); //68
            sb.Append(PPreArticle).Append(separator); //69
            sb.Append(PName).Append(separator); //70
            sb.Append(PPostArticle).Append(separator); //71
            sb.Append(PPostQualifier).Append(separator); //72
            sb.Append(PSuffix).Append(separator); //73
            sb.Append(PPostDirectional).Append(separator); //74
            sb.Append(PSuiteType).Append(separator); //75
            sb.Append(PSuiteNumber).Append(separator); //76
            sb.Append(PPostOfficeBoxType).Append(separator); //77
            sb.Append(PPostOfficeBoxNumber).Append(separator); //78
            sb.Append(PCity).Append(separator); //79
            sb.Append(PConsolidatedCity).Append(separator); //80
            sb.Append(PMinorCivilDivision).Append(separator); //81
            sb.Append(PCountySubRegion).Append(separator); //82
            sb.Append(PCounty).Append(separator); //83
            sb.Append(PState).Append(separator); //84
            sb.Append(PZip).Append(separator); //85
            sb.Append(PZipPlus1).Append(separator); //86
            sb.Append(PZipPlus2).Append(separator); //87
            sb.Append(PZipPlus3).Append(separator); //88
            sb.Append(PZipPlus4).Append(separator); //89
            sb.Append(PZipPlus5).Append(separator); //90

            sb.Append(FNumber).Append(separator); //91
            sb.Append(FNumberFractional).Append(separator); //92
            sb.Append(FPreDirectional).Append(separator); //93
            sb.Append(FPreQualifier).Append(separator); //94
            sb.Append(FPreType).Append(separator); //95
            sb.Append(FPreArticle).Append(separator); //96
            sb.Append(FName).Append(separator); //97
            sb.Append(FPostArticle).Append(separator); //98
            sb.Append(FPostQualifier).Append(separator); //99
            sb.Append(FSuffix).Append(separator); //100
            sb.Append(FPostDirectional).Append(separator); //101
            sb.Append(FSuiteType).Append(separator); //102
            sb.Append(FSuiteNumber).Append(separator); //103
            sb.Append(FPostOfficeBoxType).Append(separator); //104
            sb.Append(FPostOfficeBoxNumber).Append(separator); //105
            sb.Append(FCity).Append(separator); //106
            sb.Append(FConsolidatedCity).Append(separator); //107
            sb.Append(FMinorCivilDivision).Append(separator); //108
            sb.Append(FCountySubRegion).Append(separator); //109
            sb.Append(FCounty).Append(separator); //110
            sb.Append(FState).Append(separator); //111
            sb.Append(FZip).Append(separator); //112
            sb.Append(FZipPlus1).Append(separator); //113
            sb.Append(FZipPlus2).Append(separator); //114
            sb.Append(FZipPlus3).Append(separator); //115
            sb.Append(FZipPlus4).Append(separator); //116
            sb.Append(FZipPlus5).Append(separator); //117
            sb.Append(FArea).Append(separator); //118
            sb.Append(FAreaType).Append(separator); //119

            sb.Append(FGeometrySRID).Append(separator); //120
            if (String.Compare(separator, ",", true) == 0)
            {
                sb.Append(FGeometry.Replace(separator, ";")).Append(separator); //121
            }
            else
            {
                sb.Append(FGeometry).Append(separator); //121
            }

            sb.Append(FSource).Append(separator); //122
            sb.Append(FVintage).Append(separator); //123
            sb.Append(FPrimaryIdField).Append(separator); //124
            sb.Append(FPrimaryIdValue).Append(separator); //125
            sb.Append(FSecondaryIdField).Append(separator); //126
            sb.Append(FSecondaryIdValue).Append(separator); //127

            sb.Append(NAACCRCensusTractCertaintyCode).Append(separator); //24
            sb.Append(NAACCRCensusTractCertaintyName).Append(separator); //25

            if (CensusRecords != null)
            {
                //1990 - 17 - 27
                //2000 - 28 - 38
                //2010 - 39 - 49
                if (CensusRecords.Count == 3) // if there are three records, add them in a row
                {
                    foreach (CensusOutputRecord censusOutputRecord in CensusRecords)
                    {

                        sb.Append(censusOutputRecord.CensusBlock).Append(separator); //17
                        sb.Append(censusOutputRecord.CensusBlockGroup).Append(separator); //18
                        sb.Append(censusOutputRecord.CensusTract).Append(separator); //19
                        sb.Append(censusOutputRecord.CensusCountyFips).Append(separator); //20
                        sb.Append(censusOutputRecord.CensusCbsaFips).Append(separator); //21
                        sb.Append(censusOutputRecord.CensusCbsaMicro).Append(separator); //22
                        sb.Append(censusOutputRecord.CensusMcdFips).Append(separator); //23
                        sb.Append(censusOutputRecord.CensusMetDivFips).Append(separator); //24
                        sb.Append(censusOutputRecord.CensusMsaFips).Append(separator); //25
                        sb.Append(censusOutputRecord.CensusPlaceFips).Append(separator); //26
                        sb.Append(censusOutputRecord.CensusStateFips).Append(separator); //27

                    }
                }
                else // otherwise fill in the appropriate ones and blank out the rest
                {
                    StringBuilder sb1990 = new StringBuilder();
                    StringBuilder sb2000 = new StringBuilder();
                    StringBuilder sb2010 = new StringBuilder();

                    for (int i = 0; i < CensusRecords.Count; i++)
                    {
                        CensusOutputRecord censusOutputRecord = CensusRecords[i];
                        if (censusOutputRecord.CensusYear == Census.Core.Configurations.ServerConfigurations.CensusYear.NineteenNinety)
                        {
                            sb1990.Append(censusOutputRecord.CensusBlock).Append(separator); //17
                            sb1990.Append(censusOutputRecord.CensusBlockGroup).Append(separator); //18
                            sb1990.Append(censusOutputRecord.CensusTract).Append(separator); //19
                            sb1990.Append(censusOutputRecord.CensusCountyFips).Append(separator); //20
                            sb1990.Append(censusOutputRecord.CensusCbsaFips).Append(separator); //21
                            sb1990.Append(censusOutputRecord.CensusCbsaMicro).Append(separator); //22
                            sb1990.Append(censusOutputRecord.CensusMcdFips).Append(separator); //23
                            sb1990.Append(censusOutputRecord.CensusMetDivFips).Append(separator); //24
                            sb1990.Append(censusOutputRecord.CensusMsaFips).Append(separator); //25
                            sb1990.Append(censusOutputRecord.CensusPlaceFips).Append(separator); //26
                            sb1990.Append(censusOutputRecord.CensusStateFips).Append(separator); //27
                        }
                        else if (censusOutputRecord.CensusYear == Census.Core.Configurations.ServerConfigurations.CensusYear.TwoThousand)
                        {
                            sb2000.Append(censusOutputRecord.CensusBlock).Append(separator); //17
                            sb2000.Append(censusOutputRecord.CensusBlockGroup).Append(separator); //18
                            sb2000.Append(censusOutputRecord.CensusTract).Append(separator); //19
                            sb2000.Append(censusOutputRecord.CensusCountyFips).Append(separator); //20
                            sb2000.Append(censusOutputRecord.CensusCbsaFips).Append(separator); //21
                            sb2000.Append(censusOutputRecord.CensusCbsaMicro).Append(separator); //22
                            sb2000.Append(censusOutputRecord.CensusMcdFips).Append(separator); //23
                            sb2000.Append(censusOutputRecord.CensusMetDivFips).Append(separator); //24
                            sb2000.Append(censusOutputRecord.CensusMsaFips).Append(separator); //25
                            sb2000.Append(censusOutputRecord.CensusPlaceFips).Append(separator); //26
                            sb2000.Append(censusOutputRecord.CensusStateFips).Append(separator); //27
                        }
                        else if (censusOutputRecord.CensusYear == Census.Core.Configurations.ServerConfigurations.CensusYear.TwoThousandTen)
                        {
                            sb2010.Append(censusOutputRecord.CensusBlock).Append(separator); //17
                            sb2010.Append(censusOutputRecord.CensusBlockGroup).Append(separator); //18
                            sb2010.Append(censusOutputRecord.CensusTract).Append(separator); //19
                            sb2010.Append(censusOutputRecord.CensusCountyFips).Append(separator); //20
                            sb2010.Append(censusOutputRecord.CensusCbsaFips).Append(separator); //21
                            sb2010.Append(censusOutputRecord.CensusCbsaMicro).Append(separator); //22
                            sb2010.Append(censusOutputRecord.CensusMcdFips).Append(separator); //23
                            sb2010.Append(censusOutputRecord.CensusMetDivFips).Append(separator); //24
                            sb2010.Append(censusOutputRecord.CensusMsaFips).Append(separator); //25
                            sb2010.Append(censusOutputRecord.CensusPlaceFips).Append(separator); //26
                            sb2010.Append(censusOutputRecord.CensusStateFips).Append(separator); //27
                        }

                        if (sb1990.Length == 0)
                        {
                            sb1990.Append("").Append(separator); //17
                            sb1990.Append("").Append(separator); //18
                            sb1990.Append("").Append(separator); //19
                            sb1990.Append("").Append(separator); //20
                            sb1990.Append("").Append(separator); //21
                            sb1990.Append("").Append(separator); //22
                            sb1990.Append("").Append(separator); //23
                            sb1990.Append("").Append(separator); //24
                            sb1990.Append("").Append(separator); //25
                            sb1990.Append("").Append(separator); //26
                            sb1990.Append("").Append(separator); //27
                        }

                        if (sb2000.Length == 0)
                        {
                            sb2000.Append("").Append(separator); //17
                            sb2000.Append("").Append(separator); //18
                            sb2000.Append("").Append(separator); //19
                            sb2000.Append("").Append(separator); //20
                            sb2000.Append("").Append(separator); //21
                            sb2000.Append("").Append(separator); //22
                            sb2000.Append("").Append(separator); //23
                            sb2000.Append("").Append(separator); //24
                            sb2000.Append("").Append(separator); //25
                            sb2000.Append("").Append(separator); //26
                            sb2000.Append("").Append(separator); //27
                        }

                        if (sb2010.Length == 0)
                        {
                            sb2010.Append("").Append(separator); //17
                            sb2010.Append("").Append(separator); //18
                            sb2010.Append("").Append(separator); //19
                            sb2010.Append("").Append(separator); //20
                            sb2010.Append("").Append(separator); //21
                            sb2010.Append("").Append(separator); //22
                            sb2010.Append("").Append(separator); //23
                            sb2010.Append("").Append(separator); //24
                            sb2010.Append("").Append(separator); //25
                            sb2010.Append("").Append(separator); //26
                            sb2010.Append("").Append(separator); //27
                        }
                    }

                    sb.Append(sb1990);
                    sb.Append(sb2000);
                    sb.Append(sb2010);
                }
            }
            //PAYTON:MicroMatchStatus for v4.03
            sb.Append(MicroMatchStatus).Append(separator); //28
            //PAYTON:PENALTYCODE
            sb.Append(PenaltyCode).Append(separator); //29
            return sb.ToString();
        }

        public static string AsHeaderStringVerbose_V04_01(string separator, double version)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("TransactionId").Append(separator); //0
            sb.Append("Version").Append(separator); //1
            sb.Append("QueryStatusCodeValue").Append(separator); //2
            sb.Append("Latitude").Append(separator); //3
            sb.Append("Longitude").Append(separator);  //4
            sb.Append("NAACCRGISCoordinateQualityCode").Append(separator);  //5
            sb.Append("NAACCRGISCoordinateQualityName").Append(separator); //6
            sb.Append("MatchScore").Append(separator); //7
            sb.Append("MatchType").Append(separator); //8
            sb.Append("FeatureMatchingGeographyType").Append(separator); //9
            sb.Append("RegionSize").Append(separator); //10
            sb.Append("RegionSizeUnits").Append(separator); //11
            sb.Append("InterpolationType").Append(separator); //12
            sb.Append("InterpolationSubType").Append(separator); //13
            sb.Append("MatchedLocationType").Append(separator); //14
            sb.Append("FeatureMatchingResultType").Append(separator); //15
            sb.Append("FeatureMatchingResultCount").Append(separator); //16
            sb.Append("FeatureMatchingResultTypeNotes").Append(separator); //17
            sb.Append("FeatureMatchingResultTypeTieBreakingNotes").Append(separator); //18
            sb.Append("TieHandlingStrategyType").Append(separator); //19
            sb.Append("FeatureMatchingSelectionMethod").Append(separator); //20
            sb.Append("FeatureMatchingSelectionMethodNotes").Append(separator); //21
            sb.Append("TimeTaken").Append(separator); //22

           
            

            sb.Append("MNumber").Append(separator); //37
            sb.Append("MNumberFractional").Append(separator); //38
            sb.Append("MPreDirectional").Append(separator); //39
            sb.Append("MPreQualifier").Append(separator); //40
            sb.Append("MPreType").Append(separator); //41
            sb.Append("MPreArticle").Append(separator); //42
            sb.Append("MName").Append(separator); //43
            sb.Append("MPostArticle").Append(separator); //44
            sb.Append("MPostQualifier").Append(separator); //45
            sb.Append("MSuffix").Append(separator); //46
            sb.Append("MPostDirectional").Append(separator); //47
            sb.Append("MSuiteType").Append(separator); //48
            sb.Append("MSuiteNumber").Append(separator); //49
            sb.Append("MPostOfficeBoxType").Append(separator); //50
            sb.Append("MPostOfficeBoxNumber").Append(separator); //51
            sb.Append("MCity").Append(separator); //52
            sb.Append("MConsolidatedCity").Append(separator); //53
            sb.Append("MMinorCivilDivision").Append(separator); //54
            sb.Append("MCountySubRegion").Append(separator); //55
            sb.Append("MCounty").Append(separator); //56
            sb.Append("MState").Append(separator); //57
            sb.Append("MZip").Append(separator); //58
            sb.Append("MZipPlus1").Append(separator); //59
            sb.Append("MZipPlus2").Append(separator); //60
            sb.Append("MZipPlus3").Append(separator); //61
            sb.Append("MZipPlus4").Append(separator); //62
            sb.Append("MZipPlus5").Append(separator); //63

            sb.Append("PNumber").Append(separator); //64
            sb.Append("PNumberFractional").Append(separator); //65
            sb.Append("PPreDirectional").Append(separator); //66
            sb.Append("PPreQualifier").Append(separator); //67
            sb.Append("PPreType").Append(separator); //68
            sb.Append("PPreArticle").Append(separator); //69
            sb.Append("PName").Append(separator); //70
            sb.Append("PPostArticle").Append(separator); //71
            sb.Append("PPostQualifier").Append(separator); //72
            sb.Append("PSuffix").Append(separator); //73
            sb.Append("PPostDirectional").Append(separator); //74
            sb.Append("PSuiteType").Append(separator); //75
            sb.Append("PSuiteNumber").Append(separator); //76
            sb.Append("PPostOfficeBoxType").Append(separator); //77
            sb.Append("PPostOfficeBoxNumber").Append(separator); //78
            sb.Append("PCity").Append(separator); //79
            sb.Append("PConsolidatedCity").Append(separator); //80
            sb.Append("PMinorCivilDivision").Append(separator); //81
            sb.Append("PCountySubRegion").Append(separator); //82
            sb.Append("PCounty").Append(separator); //83
            sb.Append("PState").Append(separator); //84
            sb.Append("PZip").Append(separator); //85
            sb.Append("PZipPlus1").Append(separator); //86
            sb.Append("PZipPlus2").Append(separator); //87
            sb.Append("PZipPlus3").Append(separator); //88
            sb.Append("PZipPlus4").Append(separator); //89
            sb.Append("PZipPlus5").Append(separator); //90

            sb.Append("FNumber").Append(separator); //91
            sb.Append("FNumberFractional").Append(separator); //92
            sb.Append("FPreDirectional").Append(separator); //93
            sb.Append("FPreQualifier").Append(separator); //94
            sb.Append("FPreType").Append(separator); //95
            sb.Append("FPreArticle").Append(separator); //96
            sb.Append("FName").Append(separator); //97
            sb.Append("FPostArticle").Append(separator); //98
            sb.Append("FPostQualifier").Append(separator); //99
            sb.Append("FSuffix").Append(separator); //100
            sb.Append("FPostDirectional").Append(separator); //101
            sb.Append("FSuiteType").Append(separator); //102
            sb.Append("FSuiteNumber").Append(separator); //103
            sb.Append("FPostOfficeBoxType").Append(separator); //104
            sb.Append("FPostOfficeBoxNumber").Append(separator); //105
            sb.Append("FCity").Append(separator); //106
            sb.Append("FConsolidatedCity").Append(separator); //107
            sb.Append("FMinorCivilDivision").Append(separator); //108
            sb.Append("FCountySubRegion").Append(separator); //109
            sb.Append("FCounty").Append(separator); //110
            sb.Append("FState").Append(separator); //111
            sb.Append("FZip").Append(separator); //112
            sb.Append("FZipPlus1").Append(separator); //113
            sb.Append("FZipPlus2").Append(separator); //114
            sb.Append("FZipPlus3").Append(separator); //115
            sb.Append("FZipPlus4").Append(separator); //116
            sb.Append("FZipPlus5").Append(separator); //117
            sb.Append("FArea").Append(separator); //118
            sb.Append("FAreaType").Append(separator); //119
            sb.Append("FGeometrySRID").Append(separator); //120
            sb.Append("FGeometry").Append(separator); //121
            sb.Append("FSource").Append(separator); //122
            sb.Append("FVintage").Append(separator); //123
            sb.Append("FPrimaryIdField").Append(separator); //124
            sb.Append("FPrimaryIdValue").Append(separator); //125
            sb.Append("FSecondaryIdField").Append(separator); //126
            sb.Append("FSecondaryIdValue").Append(separator); //127

            sb.Append("NAACCRCensusTractCertaintyCode").Append(separator); //24
            sb.Append("NAACCRCensusTractCertaintyName").Append(separator); //25

            sb.Append("Census1990Block").Append(separator); //26
            sb.Append("Census1990BlockGroup").Append(separator); //27
            sb.Append("Census1990Tract").Append(separator); //28
            sb.Append("Census1990CountyFips").Append(separator); //29
            sb.Append("Census1990CbsaFips").Append(separator); //30
            sb.Append("Census1990CbsaMicro").Append(separator); //31
            sb.Append("Census1990McdFips").Append(separator); //32
            sb.Append("Census1990MetDivFips").Append(separator); //33
            sb.Append("Census1990MsaFips").Append(separator); //34
            sb.Append("Census1990PlaceFips").Append(separator); //35
            sb.Append("Census1990StateFips").Append(separator); //36

            sb.Append("Census2000Block").Append(separator); //26
            sb.Append("Census2000BlockGroup").Append(separator); //27
            sb.Append("Census2000Tract").Append(separator); //28
            sb.Append("Census2000CountyFips").Append(separator); //29
            sb.Append("Census2000CbsaFips").Append(separator); //30
            sb.Append("Census2000CbsaMicro").Append(separator); //31
            sb.Append("Census2000McdFips").Append(separator); //32
            sb.Append("Census2000MetDivFips").Append(separator); //33
            sb.Append("Census2000MsaFips").Append(separator); //34
            sb.Append("Census2000PlaceFips").Append(separator); //35
            sb.Append("Census2000StateFips").Append(separator); //36

            sb.Append("Census2010Block").Append(separator); //26
            sb.Append("Census2010BlockGroup").Append(separator); //27
            sb.Append("Census2010Tract").Append(separator); //28
            sb.Append("Census2010CountyFips").Append(separator); //29
            sb.Append("Census2010CbsaFips").Append(separator); //30
            sb.Append("Census2010CbsaMicro").Append(separator); //31
            sb.Append("Census2010McdFips").Append(separator); //32
            sb.Append("Census2010MetDivFips").Append(separator); //33
            sb.Append("Census2010MsaFips").Append(separator); //34
            sb.Append("Census2010PlaceFips").Append(separator); //35
            sb.Append("Census2010StateFips"); //36

            return sb.ToString();
        }

        public static string AsHeaderStringVerbose_V04_02(string separator, double version)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("TransactionId").Append(separator); //0
            sb.Append("Version").Append(separator); //1
            sb.Append("QueryStatusCodeValue").Append(separator); //2
            sb.Append("Latitude").Append(separator); //3
            sb.Append("Longitude").Append(separator);  //4
            sb.Append("NAACCRGISCoordinateQualityCode").Append(separator);  //5
            sb.Append("NAACCRGISCoordinateQualityName").Append(separator); //6
            sb.Append("MatchScore").Append(separator); //7
            sb.Append("MatchType").Append(separator); //8
            sb.Append("FeatureMatchingGeographyType").Append(separator); //9
            sb.Append("RegionSize").Append(separator); //10
            sb.Append("RegionSizeUnits").Append(separator); //11
            sb.Append("InterpolationType").Append(separator); //12
            sb.Append("InterpolationSubType").Append(separator); //13
            sb.Append("MatchedLocationType").Append(separator); //14
            sb.Append("FeatureMatchingResultType").Append(separator); //15
            sb.Append("FeatureMatchingResultCount").Append(separator); //16
            sb.Append("FeatureMatchingResultTypeNotes").Append(separator); //17
            sb.Append("FeatureMatchingResultTypeTieBreakingNotes").Append(separator); //18
            sb.Append("TieHandlingStrategyType").Append(separator); //19
            sb.Append("FeatureMatchingSelectionMethod").Append(separator); //20
            sb.Append("FeatureMatchingSelectionMethodNotes").Append(separator); //21
            sb.Append("TimeTaken").Append(separator); //22




            sb.Append("MNumber").Append(separator); //37
            sb.Append("MNumberFractional").Append(separator); //38
            sb.Append("MPreDirectional").Append(separator); //39
            sb.Append("MPreQualifier").Append(separator); //40
            sb.Append("MPreType").Append(separator); //41
            sb.Append("MPreArticle").Append(separator); //42
            sb.Append("MName").Append(separator); //43
            sb.Append("MPostArticle").Append(separator); //44
            sb.Append("MPostQualifier").Append(separator); //45
            sb.Append("MSuffix").Append(separator); //46
            sb.Append("MPostDirectional").Append(separator); //47
            sb.Append("MSuiteType").Append(separator); //48
            sb.Append("MSuiteNumber").Append(separator); //49
            sb.Append("MPostOfficeBoxType").Append(separator); //50
            sb.Append("MPostOfficeBoxNumber").Append(separator); //51
            sb.Append("MCity").Append(separator); //52
            sb.Append("MConsolidatedCity").Append(separator); //53
            sb.Append("MMinorCivilDivision").Append(separator); //54
            sb.Append("MCountySubRegion").Append(separator); //55
            sb.Append("MCounty").Append(separator); //56
            sb.Append("MState").Append(separator); //57
            sb.Append("MZip").Append(separator); //58
            sb.Append("MZipPlus1").Append(separator); //59
            sb.Append("MZipPlus2").Append(separator); //60
            sb.Append("MZipPlus3").Append(separator); //61
            sb.Append("MZipPlus4").Append(separator); //62
            sb.Append("MZipPlus5").Append(separator); //63

            sb.Append("PNumber").Append(separator); //64
            sb.Append("PNumberFractional").Append(separator); //65
            sb.Append("PPreDirectional").Append(separator); //66
            sb.Append("PPreQualifier").Append(separator); //67
            sb.Append("PPreType").Append(separator); //68
            sb.Append("PPreArticle").Append(separator); //69
            sb.Append("PName").Append(separator); //70
            sb.Append("PPostArticle").Append(separator); //71
            sb.Append("PPostQualifier").Append(separator); //72
            sb.Append("PSuffix").Append(separator); //73
            sb.Append("PPostDirectional").Append(separator); //74
            sb.Append("PSuiteType").Append(separator); //75
            sb.Append("PSuiteNumber").Append(separator); //76
            sb.Append("PPostOfficeBoxType").Append(separator); //77
            sb.Append("PPostOfficeBoxNumber").Append(separator); //78
            sb.Append("PCity").Append(separator); //79
            sb.Append("PConsolidatedCity").Append(separator); //80
            sb.Append("PMinorCivilDivision").Append(separator); //81
            sb.Append("PCountySubRegion").Append(separator); //82
            sb.Append("PCounty").Append(separator); //83
            sb.Append("PState").Append(separator); //84
            sb.Append("PZip").Append(separator); //85
            sb.Append("PZipPlus1").Append(separator); //86
            sb.Append("PZipPlus2").Append(separator); //87
            sb.Append("PZipPlus3").Append(separator); //88
            sb.Append("PZipPlus4").Append(separator); //89
            sb.Append("PZipPlus5").Append(separator); //90

            sb.Append("FNumber").Append(separator); //91
            sb.Append("FNumberFractional").Append(separator); //92
            sb.Append("FPreDirectional").Append(separator); //93
            sb.Append("FPreQualifier").Append(separator); //94
            sb.Append("FPreType").Append(separator); //95
            sb.Append("FPreArticle").Append(separator); //96
            sb.Append("FName").Append(separator); //97
            sb.Append("FPostArticle").Append(separator); //98
            sb.Append("FPostQualifier").Append(separator); //99
            sb.Append("FSuffix").Append(separator); //100
            sb.Append("FPostDirectional").Append(separator); //101
            sb.Append("FSuiteType").Append(separator); //102
            sb.Append("FSuiteNumber").Append(separator); //103
            sb.Append("FPostOfficeBoxType").Append(separator); //104
            sb.Append("FPostOfficeBoxNumber").Append(separator); //105
            sb.Append("FCity").Append(separator); //106
            sb.Append("FConsolidatedCity").Append(separator); //107
            sb.Append("FMinorCivilDivision").Append(separator); //108
            sb.Append("FCountySubRegion").Append(separator); //109
            sb.Append("FCounty").Append(separator); //110
            sb.Append("FState").Append(separator); //111
            sb.Append("FZip").Append(separator); //112
            sb.Append("FZipPlus1").Append(separator); //113
            sb.Append("FZipPlus2").Append(separator); //114
            sb.Append("FZipPlus3").Append(separator); //115
            sb.Append("FZipPlus4").Append(separator); //116
            sb.Append("FZipPlus5").Append(separator); //117
            sb.Append("FArea").Append(separator); //118
            sb.Append("FAreaType").Append(separator); //119
            sb.Append("FGeometrySRID").Append(separator); //120
            sb.Append("FGeometry").Append(separator); //121
            sb.Append("FSource").Append(separator); //122
            sb.Append("FVintage").Append(separator); //123
            sb.Append("FPrimaryIdField").Append(separator); //124
            sb.Append("FPrimaryIdValue").Append(separator); //125
            sb.Append("FSecondaryIdField").Append(separator); //126
            sb.Append("FSecondaryIdValue").Append(separator); //127

            sb.Append("NAACCRCensusTractCertaintyCode").Append(separator); //24
            sb.Append("NAACCRCensusTractCertaintyName").Append(separator); //25

            sb.Append("Census1990Block").Append(separator); //26
            sb.Append("Census1990BlockGroup").Append(separator); //27
            sb.Append("Census1990Tract").Append(separator); //28
            sb.Append("Census1990CountyFips").Append(separator); //29
            sb.Append("Census1990CbsaFips").Append(separator); //30
            sb.Append("Census1990CbsaMicro").Append(separator); //31
            sb.Append("Census1990McdFips").Append(separator); //32
            sb.Append("Census1990MetDivFips").Append(separator); //33
            sb.Append("Census1990MsaFips").Append(separator); //34
            sb.Append("Census1990PlaceFips").Append(separator); //35
            sb.Append("Census1990StateFips").Append(separator); //36

            sb.Append("Census2000Block").Append(separator); //26
            sb.Append("Census2000BlockGroup").Append(separator); //27
            sb.Append("Census2000Tract").Append(separator); //28
            sb.Append("Census2000CountyFips").Append(separator); //29
            sb.Append("Census2000CbsaFips").Append(separator); //30
            sb.Append("Census2000CbsaMicro").Append(separator); //31
            sb.Append("Census2000McdFips").Append(separator); //32
            sb.Append("Census2000MetDivFips").Append(separator); //33
            sb.Append("Census2000MsaFips").Append(separator); //34
            sb.Append("Census2000PlaceFips").Append(separator); //35
            sb.Append("Census2000StateFips").Append(separator); //36

            sb.Append("Census2010Block").Append(separator); //26
            sb.Append("Census2010BlockGroup").Append(separator); //27
            sb.Append("Census2010Tract").Append(separator); //28
            sb.Append("Census2010CountyFips").Append(separator); //29
            sb.Append("Census2010CbsaFips").Append(separator); //30
            sb.Append("Census2010CbsaMicro").Append(separator); //31
            sb.Append("Census2010McdFips").Append(separator); //32
            sb.Append("Census2010MetDivFips").Append(separator); //33
            sb.Append("Census2010MsaFips").Append(separator); //34
            sb.Append("Census2010PlaceFips").Append(separator); //35
            sb.Append("Census2010StateFips").Append(separator); //36

            //PAYTON:MicroMatchStatus for v4.03
            //sb.Append("MicroMatchStatus"); //37
            return sb.ToString();
        }

        public static string AsHeaderStringVerbose_V04_03(string separator, double version)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("TransactionId").Append(separator); //0
            sb.Append("Version").Append(separator); //1
            sb.Append("QueryStatusCodeValue").Append(separator); //2
            sb.Append("Latitude").Append(separator); //3
            sb.Append("Longitude").Append(separator);  //4
            sb.Append("NAACCRGISCoordinateQualityCode").Append(separator);  //5
            sb.Append("NAACCRGISCoordinateQualityName").Append(separator); //6
            sb.Append("MatchScore").Append(separator); //7
            sb.Append("MatchType").Append(separator); //8
            sb.Append("FeatureMatchingGeographyType").Append(separator); //9
            sb.Append("RegionSize").Append(separator); //10
            sb.Append("RegionSizeUnits").Append(separator); //11
            sb.Append("InterpolationType").Append(separator); //12
            sb.Append("InterpolationSubType").Append(separator); //13
            sb.Append("MatchedLocationType").Append(separator); //14
            sb.Append("FeatureMatchingResultType").Append(separator); //15
            sb.Append("FeatureMatchingResultCount").Append(separator); //16
            sb.Append("FeatureMatchingResultTypeNotes").Append(separator); //17
            sb.Append("FeatureMatchingResultTypeTieBreakingNotes").Append(separator); //18
            sb.Append("TieHandlingStrategyType").Append(separator); //19
            sb.Append("FeatureMatchingSelectionMethod").Append(separator); //20
            sb.Append("FeatureMatchingSelectionMethodNotes").Append(separator); //21
            sb.Append("TimeTaken").Append(separator); //22




            sb.Append("MNumber").Append(separator); //37
            sb.Append("MNumberFractional").Append(separator); //38
            sb.Append("MPreDirectional").Append(separator); //39
            sb.Append("MPreQualifier").Append(separator); //40
            sb.Append("MPreType").Append(separator); //41
            sb.Append("MPreArticle").Append(separator); //42
            sb.Append("MName").Append(separator); //43
            sb.Append("MPostArticle").Append(separator); //44
            sb.Append("MPostQualifier").Append(separator); //45
            sb.Append("MSuffix").Append(separator); //46
            sb.Append("MPostDirectional").Append(separator); //47
            sb.Append("MSuiteType").Append(separator); //48
            sb.Append("MSuiteNumber").Append(separator); //49
            sb.Append("MPostOfficeBoxType").Append(separator); //50
            sb.Append("MPostOfficeBoxNumber").Append(separator); //51
            sb.Append("MCity").Append(separator); //52
            sb.Append("MConsolidatedCity").Append(separator); //53
            sb.Append("MMinorCivilDivision").Append(separator); //54
            sb.Append("MCountySubRegion").Append(separator); //55
            sb.Append("MCounty").Append(separator); //56
            sb.Append("MState").Append(separator); //57
            sb.Append("MZip").Append(separator); //58
            sb.Append("MZipPlus1").Append(separator); //59
            sb.Append("MZipPlus2").Append(separator); //60
            sb.Append("MZipPlus3").Append(separator); //61
            sb.Append("MZipPlus4").Append(separator); //62
            sb.Append("MZipPlus5").Append(separator); //63

            sb.Append("PNumber").Append(separator); //64
            sb.Append("PNumberFractional").Append(separator); //65
            sb.Append("PPreDirectional").Append(separator); //66
            sb.Append("PPreQualifier").Append(separator); //67
            sb.Append("PPreType").Append(separator); //68
            sb.Append("PPreArticle").Append(separator); //69
            sb.Append("PName").Append(separator); //70
            sb.Append("PPostArticle").Append(separator); //71
            sb.Append("PPostQualifier").Append(separator); //72
            sb.Append("PSuffix").Append(separator); //73
            sb.Append("PPostDirectional").Append(separator); //74
            sb.Append("PSuiteType").Append(separator); //75
            sb.Append("PSuiteNumber").Append(separator); //76
            sb.Append("PPostOfficeBoxType").Append(separator); //77
            sb.Append("PPostOfficeBoxNumber").Append(separator); //78
            sb.Append("PCity").Append(separator); //79
            sb.Append("PConsolidatedCity").Append(separator); //80
            sb.Append("PMinorCivilDivision").Append(separator); //81
            sb.Append("PCountySubRegion").Append(separator); //82
            sb.Append("PCounty").Append(separator); //83
            sb.Append("PState").Append(separator); //84
            sb.Append("PZip").Append(separator); //85
            sb.Append("PZipPlus1").Append(separator); //86
            sb.Append("PZipPlus2").Append(separator); //87
            sb.Append("PZipPlus3").Append(separator); //88
            sb.Append("PZipPlus4").Append(separator); //89
            sb.Append("PZipPlus5").Append(separator); //90

            sb.Append("FNumber").Append(separator); //91
            sb.Append("FNumberFractional").Append(separator); //92
            sb.Append("FPreDirectional").Append(separator); //93
            sb.Append("FPreQualifier").Append(separator); //94
            sb.Append("FPreType").Append(separator); //95
            sb.Append("FPreArticle").Append(separator); //96
            sb.Append("FName").Append(separator); //97
            sb.Append("FPostArticle").Append(separator); //98
            sb.Append("FPostQualifier").Append(separator); //99
            sb.Append("FSuffix").Append(separator); //100
            sb.Append("FPostDirectional").Append(separator); //101
            sb.Append("FSuiteType").Append(separator); //102
            sb.Append("FSuiteNumber").Append(separator); //103
            sb.Append("FPostOfficeBoxType").Append(separator); //104
            sb.Append("FPostOfficeBoxNumber").Append(separator); //105
            sb.Append("FCity").Append(separator); //106
            sb.Append("FConsolidatedCity").Append(separator); //107
            sb.Append("FMinorCivilDivision").Append(separator); //108
            sb.Append("FCountySubRegion").Append(separator); //109
            sb.Append("FCounty").Append(separator); //110
            sb.Append("FState").Append(separator); //111
            sb.Append("FZip").Append(separator); //112
            sb.Append("FZipPlus1").Append(separator); //113
            sb.Append("FZipPlus2").Append(separator); //114
            sb.Append("FZipPlus3").Append(separator); //115
            sb.Append("FZipPlus4").Append(separator); //116
            sb.Append("FZipPlus5").Append(separator); //117
            sb.Append("FArea").Append(separator); //118
            sb.Append("FAreaType").Append(separator); //119
            sb.Append("FGeometrySRID").Append(separator); //120
            sb.Append("FGeometry").Append(separator); //121
            sb.Append("FSource").Append(separator); //122
            sb.Append("FVintage").Append(separator); //123
            sb.Append("FPrimaryIdField").Append(separator); //124
            sb.Append("FPrimaryIdValue").Append(separator); //125
            sb.Append("FSecondaryIdField").Append(separator); //126
            sb.Append("FSecondaryIdValue").Append(separator); //127

            sb.Append("NAACCRCensusTractCertaintyCode").Append(separator); //24
            sb.Append("NAACCRCensusTractCertaintyName").Append(separator); //25

            sb.Append("Census1990Block").Append(separator); //26
            sb.Append("Census1990BlockGroup").Append(separator); //27
            sb.Append("Census1990Tract").Append(separator); //28
            sb.Append("Census1990CountyFips").Append(separator); //29
            sb.Append("Census1990CbsaFips").Append(separator); //30
            sb.Append("Census1990CbsaMicro").Append(separator); //31
            sb.Append("Census1990McdFips").Append(separator); //32
            sb.Append("Census1990MetDivFips").Append(separator); //33
            sb.Append("Census1990MsaFips").Append(separator); //34
            sb.Append("Census1990PlaceFips").Append(separator); //35
            sb.Append("Census1990StateFips").Append(separator); //36

            sb.Append("Census2000Block").Append(separator); //26
            sb.Append("Census2000BlockGroup").Append(separator); //27
            sb.Append("Census2000Tract").Append(separator); //28
            sb.Append("Census2000CountyFips").Append(separator); //29
            sb.Append("Census2000CbsaFips").Append(separator); //30
            sb.Append("Census2000CbsaMicro").Append(separator); //31
            sb.Append("Census2000McdFips").Append(separator); //32
            sb.Append("Census2000MetDivFips").Append(separator); //33
            sb.Append("Census2000MsaFips").Append(separator); //34
            sb.Append("Census2000PlaceFips").Append(separator); //35
            sb.Append("Census2000StateFips").Append(separator); //36

            sb.Append("Census2010Block").Append(separator); //26
            sb.Append("Census2010BlockGroup").Append(separator); //27
            sb.Append("Census2010Tract").Append(separator); //28
            sb.Append("Census2010CountyFips").Append(separator); //29
            sb.Append("Census2010CbsaFips").Append(separator); //30
            sb.Append("Census2010CbsaMicro").Append(separator); //31
            sb.Append("Census2010McdFips").Append(separator); //32
            sb.Append("Census2010MetDivFips").Append(separator); //33
            sb.Append("Census2010MsaFips").Append(separator); //34
            sb.Append("Census2010PlaceFips").Append(separator); //35
            sb.Append("Census2010StateFips").Append(separator); //36

            //PAYTON:MicroMatchStatus
            sb.Append("MicroMatchStatus"); //37
            return sb.ToString();
        }

        public static string AsHeaderStringVerbose_V04_04(string separator, double version)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("TransactionId").Append(separator); //0
            sb.Append("Version").Append(separator); //1
            sb.Append("QueryStatusCodeValue").Append(separator); //2
            sb.Append("Latitude").Append(separator); //3
            sb.Append("Longitude").Append(separator);  //4
            sb.Append("NAACCRGISCoordinateQualityCode").Append(separator);  //5
            sb.Append("NAACCRGISCoordinateQualityName").Append(separator); //6
            sb.Append("MatchScore").Append(separator); //7
            sb.Append("MatchType").Append(separator); //8
            sb.Append("FeatureMatchingGeographyType").Append(separator); //9
            sb.Append("RegionSize").Append(separator); //10
            sb.Append("RegionSizeUnits").Append(separator); //11
            sb.Append("InterpolationType").Append(separator); //12
            sb.Append("InterpolationSubType").Append(separator); //13
            sb.Append("MatchedLocationType").Append(separator); //14
            sb.Append("FeatureMatchingResultType").Append(separator); //15
            sb.Append("FeatureMatchingResultCount").Append(separator); //16
            sb.Append("FeatureMatchingResultTypeNotes").Append(separator); //17
            sb.Append("FeatureMatchingResultTypeTieBreakingNotes").Append(separator); //18
            sb.Append("TieHandlingStrategyType").Append(separator); //19
            sb.Append("FeatureMatchingSelectionMethod").Append(separator); //20
            sb.Append("FeatureMatchingSelectionMethodNotes").Append(separator); //21
            sb.Append("TimeTaken").Append(separator); //22




            sb.Append("MNumber").Append(separator); //37
            sb.Append("MNumberFractional").Append(separator); //38
            sb.Append("MPreDirectional").Append(separator); //39
            sb.Append("MPreQualifier").Append(separator); //40
            sb.Append("MPreType").Append(separator); //41
            sb.Append("MPreArticle").Append(separator); //42
            sb.Append("MName").Append(separator); //43
            sb.Append("MPostArticle").Append(separator); //44
            sb.Append("MPostQualifier").Append(separator); //45
            sb.Append("MSuffix").Append(separator); //46
            sb.Append("MPostDirectional").Append(separator); //47
            sb.Append("MSuiteType").Append(separator); //48
            sb.Append("MSuiteNumber").Append(separator); //49
            sb.Append("MPostOfficeBoxType").Append(separator); //50
            sb.Append("MPostOfficeBoxNumber").Append(separator); //51
            sb.Append("MCity").Append(separator); //52
            sb.Append("MConsolidatedCity").Append(separator); //53
            sb.Append("MMinorCivilDivision").Append(separator); //54
            sb.Append("MCountySubRegion").Append(separator); //55
            sb.Append("MCounty").Append(separator); //56
            sb.Append("MState").Append(separator); //57
            sb.Append("MZip").Append(separator); //58
            sb.Append("MZipPlus1").Append(separator); //59
            sb.Append("MZipPlus2").Append(separator); //60
            sb.Append("MZipPlus3").Append(separator); //61
            sb.Append("MZipPlus4").Append(separator); //62
            sb.Append("MZipPlus5").Append(separator); //63

            sb.Append("PNumber").Append(separator); //64
            sb.Append("PNumberFractional").Append(separator); //65
            sb.Append("PPreDirectional").Append(separator); //66
            sb.Append("PPreQualifier").Append(separator); //67
            sb.Append("PPreType").Append(separator); //68
            sb.Append("PPreArticle").Append(separator); //69
            sb.Append("PName").Append(separator); //70
            sb.Append("PPostArticle").Append(separator); //71
            sb.Append("PPostQualifier").Append(separator); //72
            sb.Append("PSuffix").Append(separator); //73
            sb.Append("PPostDirectional").Append(separator); //74
            sb.Append("PSuiteType").Append(separator); //75
            sb.Append("PSuiteNumber").Append(separator); //76
            sb.Append("PPostOfficeBoxType").Append(separator); //77
            sb.Append("PPostOfficeBoxNumber").Append(separator); //78
            sb.Append("PCity").Append(separator); //79
            sb.Append("PConsolidatedCity").Append(separator); //80
            sb.Append("PMinorCivilDivision").Append(separator); //81
            sb.Append("PCountySubRegion").Append(separator); //82
            sb.Append("PCounty").Append(separator); //83
            sb.Append("PState").Append(separator); //84
            sb.Append("PZip").Append(separator); //85
            sb.Append("PZipPlus1").Append(separator); //86
            sb.Append("PZipPlus2").Append(separator); //87
            sb.Append("PZipPlus3").Append(separator); //88
            sb.Append("PZipPlus4").Append(separator); //89
            sb.Append("PZipPlus5").Append(separator); //90

            sb.Append("FNumber").Append(separator); //91
            sb.Append("FNumberFractional").Append(separator); //92
            sb.Append("FPreDirectional").Append(separator); //93
            sb.Append("FPreQualifier").Append(separator); //94
            sb.Append("FPreType").Append(separator); //95
            sb.Append("FPreArticle").Append(separator); //96
            sb.Append("FName").Append(separator); //97
            sb.Append("FPostArticle").Append(separator); //98
            sb.Append("FPostQualifier").Append(separator); //99
            sb.Append("FSuffix").Append(separator); //100
            sb.Append("FPostDirectional").Append(separator); //101
            sb.Append("FSuiteType").Append(separator); //102
            sb.Append("FSuiteNumber").Append(separator); //103
            sb.Append("FPostOfficeBoxType").Append(separator); //104
            sb.Append("FPostOfficeBoxNumber").Append(separator); //105
            sb.Append("FCity").Append(separator); //106
            sb.Append("FConsolidatedCity").Append(separator); //107
            sb.Append("FMinorCivilDivision").Append(separator); //108
            sb.Append("FCountySubRegion").Append(separator); //109
            sb.Append("FCounty").Append(separator); //110
            sb.Append("FState").Append(separator); //111
            sb.Append("FZip").Append(separator); //112
            sb.Append("FZipPlus1").Append(separator); //113
            sb.Append("FZipPlus2").Append(separator); //114
            sb.Append("FZipPlus3").Append(separator); //115
            sb.Append("FZipPlus4").Append(separator); //116
            sb.Append("FZipPlus5").Append(separator); //117
            sb.Append("FArea").Append(separator); //118
            sb.Append("FAreaType").Append(separator); //119
            sb.Append("FGeometrySRID").Append(separator); //120
            sb.Append("FGeometry").Append(separator); //121
            sb.Append("FSource").Append(separator); //122
            sb.Append("FVintage").Append(separator); //123
            sb.Append("FPrimaryIdField").Append(separator); //124
            sb.Append("FPrimaryIdValue").Append(separator); //125
            sb.Append("FSecondaryIdField").Append(separator); //126
            sb.Append("FSecondaryIdValue").Append(separator); //127

            sb.Append("NAACCRCensusTractCertaintyCode").Append(separator); //24
            sb.Append("NAACCRCensusTractCertaintyName").Append(separator); //25

            sb.Append("Census1990Block").Append(separator); //26
            sb.Append("Census1990BlockGroup").Append(separator); //27
            sb.Append("Census1990Tract").Append(separator); //28
            sb.Append("Census1990CountyFips").Append(separator); //29
            sb.Append("Census1990CbsaFips").Append(separator); //30
            sb.Append("Census1990CbsaMicro").Append(separator); //31
            sb.Append("Census1990McdFips").Append(separator); //32
            sb.Append("Census1990MetDivFips").Append(separator); //33
            sb.Append("Census1990MsaFips").Append(separator); //34
            sb.Append("Census1990PlaceFips").Append(separator); //35
            sb.Append("Census1990StateFips").Append(separator); //36

            sb.Append("Census2000Block").Append(separator); //26
            sb.Append("Census2000BlockGroup").Append(separator); //27
            sb.Append("Census2000Tract").Append(separator); //28
            sb.Append("Census2000CountyFips").Append(separator); //29
            sb.Append("Census2000CbsaFips").Append(separator); //30
            sb.Append("Census2000CbsaMicro").Append(separator); //31
            sb.Append("Census2000McdFips").Append(separator); //32
            sb.Append("Census2000MetDivFips").Append(separator); //33
            sb.Append("Census2000MsaFips").Append(separator); //34
            sb.Append("Census2000PlaceFips").Append(separator); //35
            sb.Append("Census2000StateFips").Append(separator); //36

            sb.Append("Census2010Block").Append(separator); //26
            sb.Append("Census2010BlockGroup").Append(separator); //27
            sb.Append("Census2010Tract").Append(separator); //28
            sb.Append("Census2010CountyFips").Append(separator); //29
            sb.Append("Census2010CbsaFips").Append(separator); //30
            sb.Append("Census2010CbsaMicro").Append(separator); //31
            sb.Append("Census2010McdFips").Append(separator); //32
            sb.Append("Census2010MetDivFips").Append(separator); //33
            sb.Append("Census2010MsaFips").Append(separator); //34
            sb.Append("Census2010PlaceFips").Append(separator); //35
            sb.Append("Census2010StateFips").Append(separator); //36

            //PAYTON:MicroMatchStatus
            sb.Append("MicroMatchStatus"); //37
            //PAYTON:PENALTYCODE
            sb.Append("PenaltyCode");
            return sb.ToString();
        }


        // added:      NAACCRGISCoordinateQualityType, NAACCRGISCoordinateQualityCode, NAACCRCensusTractCertaintyCode, NAACCRCensusTractCertaintyType , 

        public string AsString_V03_01(string separator, double version)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(TransactionId).Append(separator); //0
            sb.Append(Version).Append(separator); //1
            sb.Append(QueryStatusCodeValue).Append(separator); //2
            sb.Append(Latitude).Append(separator); //3
            sb.Append(Longitude).Append(separator);  //4
            sb.Append(NAACCRGISCoordinateQualityCode).Append(separator);  //5
            sb.Append(NAACCRGISCoordinateQualityName).Append(separator); //6
            sb.Append(MatchScore).Append(separator); //7
            sb.Append(MatchType).Append(separator); //8
            sb.Append(FeatureMatchingGeographyType).Append(separator); //9
            sb.Append(RegionSize).Append(separator); //10
            sb.Append(RegionSizeUnits).Append(separator); //11
            sb.Append(MatchedLocationType).Append(separator); //12
            sb.Append(TimeTaken).Append(separator); //13

            
            return sb.ToString();
        }

        public string AsHeaderString_V03_01(string separator, double version)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("TransactionId").Append(separator); //0
            sb.Append("Version").Append(separator); //1
            sb.Append("QueryStatusCodeValue").Append(separator); //2
            sb.Append("Latitude").Append(separator); //3
            sb.Append("Longitude").Append(separator);  //4
            sb.Append("NAACCRGISCoordinateQualityCode").Append(separator);  //5
            sb.Append("NAACCRGISCoordinateQualityName").Append(separator); //6
            sb.Append("MatchScore").Append(separator); //7
            sb.Append("MatchType").Append(separator); //8
            sb.Append("FeatureMatchingGeographyType").Append(separator); //9
            sb.Append("RegionSize").Append(separator); //10
            sb.Append("RegionSizeUnits").Append(separator); //11
            sb.Append("MatchedLocationType").Append(separator); //12
            sb.Append("TimeTaken").Append(separator); //13

            return sb.ToString();
        }

        public string AsStringWithCensus_V03_01(string separator, double version)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(TransactionId).Append(separator); //0
            sb.Append(Version).Append(separator); //1
            sb.Append(QueryStatusCodeValue).Append(separator); //2
            sb.Append(Latitude).Append(separator); //3
            sb.Append(Longitude).Append(separator);  //4
            sb.Append(NAACCRGISCoordinateQualityCode).Append(separator);  //5
            sb.Append(NAACCRGISCoordinateQualityName).Append(separator); //6
            sb.Append(MatchScore).Append(separator); //7
            sb.Append(MatchType).Append(separator); //8
            sb.Append(FeatureMatchingGeographyType).Append(separator); //9
            sb.Append(RegionSize).Append(separator); //10
            sb.Append(RegionSizeUnits).Append(separator); //11
            sb.Append(MatchedLocationType).Append(separator); //12
            sb.Append(TimeTaken).Append(separator); //13

            sb.Append(CensusYear).Append(separator); //14
            sb.Append(NAACCRCensusTractCertaintyCode).Append(separator); //15
            sb.Append(NAACCRCensusTractCertaintyName).Append(separator); //16
            sb.Append(CensusBlock).Append(separator); //17
            sb.Append(CensusBlockGroup).Append(separator); //18
            sb.Append(CensusTract).Append(separator); //19
            sb.Append(CensusCountyFips).Append(separator); //20
            sb.Append(CensusCbsaFips).Append(separator); //21
            sb.Append(CensusCbsaMicro).Append(separator); //22
            sb.Append(CensusMcdFips).Append(separator); //23
            sb.Append(CensusMetDivFips).Append(separator); //24
            sb.Append(CensusMsaFips).Append(separator); //25
            sb.Append(CensusPlaceFips).Append(separator); //26
            sb.Append(CensusStateFips).Append(separator); //27


            return sb.ToString();
        }

        public string AsHeaderStringWithCensus_V03_01(string separator, double version)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("TransactionId").Append(separator); //0
            sb.Append("Version").Append(separator); //1
            sb.Append("QueryStatusCodeValue").Append(separator); //2
            sb.Append("Latitude").Append(separator); //3
            sb.Append("Longitude").Append(separator);  //4
            sb.Append("NAACCRGISCoordinateQualityCode").Append(separator);  //5
            sb.Append("NAACCRGISCoordinateQualityName").Append(separator); //6
            sb.Append("MatchScore").Append(separator); //7
            sb.Append("MatchType").Append(separator); //8
            sb.Append("FeatureMatchingGeographyType").Append(separator); //9
            sb.Append("RegionSize").Append(separator); //10
            sb.Append("RegionSizeUnits").Append(separator); //11
            sb.Append("MatchedLocationType").Append(separator); //12
            sb.Append("TimeTaken").Append(separator); //13

            sb.Append("CensusYear").Append(separator); //14
            sb.Append("NAACCRCensusTractCertaintyCode").Append(separator); //15
            sb.Append("NAACCRCensusTractCertaintyName").Append(separator); //16
            sb.Append("CensusBlock").Append(separator); //17
            sb.Append("CensusBlockGroup").Append(separator); //18
            sb.Append("CensusTract").Append(separator); //19
            sb.Append("CensusCountyFips").Append(separator); //20
            sb.Append("CensusCbsaFips").Append(separator); //21
            sb.Append("CensusCbsaMicro").Append(separator); //22
            sb.Append("CensusMcdFips").Append(separator); //23
            sb.Append("CensusMetDivFips").Append(separator); //24
            sb.Append("CensusMsaFips").Append(separator); //25
            sb.Append("CensusPlaceFips").Append(separator); //26
            sb.Append("CensusStateFips").Append(separator); //27

            return sb.ToString();
        }


        // added:      NAACCRGISCoordinateQualityType, NAACCRGISCoordinateQualityCode, NAACCRCensusTractCertaintyCode, NAACCRCensusTractCertaintyType , 

        public string AsStringVerbose_V03_01(string separator, double version)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(TransactionId).Append(separator); //0
            sb.Append(Version).Append(separator); //1
            sb.Append(QueryStatusCodeValue).Append(separator); //2
            sb.Append(Latitude).Append(separator); //3
            sb.Append(Longitude).Append(separator);  //4
            sb.Append(NAACCRGISCoordinateQualityCode).Append(separator);  //5
            sb.Append(NAACCRGISCoordinateQualityName).Append(separator); //6
            sb.Append(MatchScore).Append(separator); //7
            sb.Append(MatchType).Append(separator); //8
            sb.Append(FeatureMatchingGeographyType).Append(separator); //9
            sb.Append(RegionSize).Append(separator); //10
            sb.Append(RegionSizeUnits).Append(separator); //11
            sb.Append(InterpolationType).Append(separator); //12
            sb.Append(InterpolationSubType).Append(separator); //13
            sb.Append(MatchedLocationType).Append(separator); //14
            sb.Append(FeatureMatchingResultType).Append(separator); //15
            sb.Append(FeatureMatchingResultCount).Append(separator); //16
            sb.Append(FeatureMatchingResultTypeNotes).Append(separator); //17
            sb.Append(FeatureMatchingResultTypeTieBreakingNotes).Append(separator); //18
            sb.Append(TieHandlingStrategyType).Append(separator); //19
            sb.Append(FeatureMatchingSelectionMethod).Append(separator); //20
            sb.Append(FeatureMatchingSelectionMethodNotes).Append(separator); //21
            sb.Append(TimeTaken).Append(separator); //22

            sb.Append(CensusYear).Append(separator); //23
            sb.Append(NAACCRCensusTractCertaintyCode).Append(separator); //24
            sb.Append(NAACCRCensusTractCertaintyName).Append(separator); //25
            sb.Append(CensusBlock).Append(separator); //26
            sb.Append(CensusBlockGroup).Append(separator); //27
            sb.Append(CensusTract).Append(separator); //28
            sb.Append(CensusCountyFips).Append(separator); //29
            sb.Append(CensusCbsaFips).Append(separator); //30
            sb.Append(CensusCbsaMicro).Append(separator); //31
            sb.Append(CensusMcdFips).Append(separator); //32
            sb.Append(CensusMetDivFips).Append(separator); //33
            sb.Append(CensusMsaFips).Append(separator); //34
            sb.Append(CensusPlaceFips).Append(separator); //35
            sb.Append(CensusStateFips).Append(separator); //36

            sb.Append(MNumber).Append(separator); //37
            sb.Append(MNumberFractional).Append(separator); //38
            sb.Append(MPreDirectional).Append(separator); //39
            sb.Append(MPreQualifier).Append(separator); //40
            sb.Append(MPreType).Append(separator); //41
            sb.Append(MPreArticle).Append(separator); //42
            sb.Append(MName).Append(separator); //43
            sb.Append(MPostArticle).Append(separator); //44
            sb.Append(MPostQualifier).Append(separator); //45
            sb.Append(MSuffix).Append(separator); //46
            sb.Append(MPostDirectional).Append(separator); //47
            sb.Append(MSuiteType).Append(separator); //48
            sb.Append(MSuiteNumber).Append(separator); //49
            sb.Append(MPostOfficeBoxType).Append(separator); //50
            sb.Append(MPostOfficeBoxNumber).Append(separator); //51
            sb.Append(MCity).Append(separator); //52
            sb.Append(MConsolidatedCity).Append(separator); //53
            sb.Append(MMinorCivilDivision).Append(separator); //54
            sb.Append(MCountySubRegion).Append(separator); //55
            sb.Append(MCounty).Append(separator); //56
            sb.Append(MState).Append(separator); //57
            sb.Append(MZip).Append(separator); //58
            sb.Append(MZipPlus1).Append(separator); //59
            sb.Append(MZipPlus2).Append(separator); //60
            sb.Append(MZipPlus3).Append(separator); //61
            sb.Append(MZipPlus4).Append(separator); //62
            sb.Append(MZipPlus5).Append(separator); //63

            sb.Append(PNumber).Append(separator); //64
            sb.Append(PNumberFractional).Append(separator); //65
            sb.Append(PPreDirectional).Append(separator); //66
            sb.Append(PPreQualifier).Append(separator); //67
            sb.Append(PPreType).Append(separator); //68
            sb.Append(PPreArticle).Append(separator); //69
            sb.Append(PName).Append(separator); //70
            sb.Append(PPostArticle).Append(separator); //71
            sb.Append(PPostQualifier).Append(separator); //72
            sb.Append(PSuffix).Append(separator); //73
            sb.Append(PPostDirectional).Append(separator); //74
            sb.Append(PSuiteType).Append(separator); //75
            sb.Append(PSuiteNumber).Append(separator); //76
            sb.Append(PPostOfficeBoxType).Append(separator); //77
            sb.Append(PPostOfficeBoxNumber).Append(separator); //78
            sb.Append(PCity).Append(separator); //79
            sb.Append(PConsolidatedCity).Append(separator); //80
            sb.Append(PMinorCivilDivision).Append(separator); //81
            sb.Append(PCountySubRegion).Append(separator); //82
            sb.Append(PCounty).Append(separator); //83
            sb.Append(PState).Append(separator); //84
            sb.Append(PZip).Append(separator); //85
            sb.Append(PZipPlus1).Append(separator); //86
            sb.Append(PZipPlus2).Append(separator); //87
            sb.Append(PZipPlus3).Append(separator); //88
            sb.Append(PZipPlus4).Append(separator); //89
            sb.Append(PZipPlus5).Append(separator); //90

            sb.Append(FNumber).Append(separator); //91
            sb.Append(FNumberFractional).Append(separator); //92
            sb.Append(FPreDirectional).Append(separator); //93
            sb.Append(FPreQualifier).Append(separator); //94
            sb.Append(FPreType).Append(separator); //95
            sb.Append(FPreArticle).Append(separator); //96
            sb.Append(FName).Append(separator); //97
            sb.Append(FPostArticle).Append(separator); //98
            sb.Append(FPostQualifier).Append(separator); //99
            sb.Append(FSuffix).Append(separator); //100
            sb.Append(FPostDirectional).Append(separator); //101
            sb.Append(FSuiteType).Append(separator); //102
            sb.Append(FSuiteNumber).Append(separator); //103
            sb.Append(FPostOfficeBoxType).Append(separator); //104
            sb.Append(FPostOfficeBoxNumber).Append(separator); //105
            sb.Append(FCity).Append(separator); //106
            sb.Append(FConsolidatedCity).Append(separator); //107
            sb.Append(FMinorCivilDivision).Append(separator); //108
            sb.Append(FCountySubRegion).Append(separator); //109
            sb.Append(FCounty).Append(separator); //110
            sb.Append(FState).Append(separator); //111
            sb.Append(FZip).Append(separator); //112
            sb.Append(FZipPlus1).Append(separator); //113
            sb.Append(FZipPlus2).Append(separator); //114
            sb.Append(FZipPlus3).Append(separator); //115
            sb.Append(FZipPlus4).Append(separator); //116
            sb.Append(FZipPlus5).Append(separator); //117
            sb.Append(FArea).Append(separator); //118
            sb.Append(FAreaType).Append(separator); //119

            sb.Append(FGeometrySRID).Append(separator); //120
            if (String.Compare(separator, ",", true) == 0)
            {
                sb.Append(FGeometry.Replace(separator, ";")).Append(separator); //121
            }
            else
            {
                sb.Append(FGeometry).Append(separator); //121
            }

            sb.Append(FSource).Append(separator); //122
            sb.Append(FVintage).Append(separator); //123
            sb.Append(FPrimaryIdField).Append(separator); //124
            sb.Append(FPrimaryIdValue).Append(separator); //125
            sb.Append(FSecondaryIdField).Append(separator); //126
            sb.Append(FSecondaryIdValue); //127

            return sb.ToString();
        }

        public string AsHeaderStringVerbose_V03_01(string separator, double version)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("TransactionId").Append(separator); //0
            sb.Append("Version").Append(separator); //1
            sb.Append("QueryStatusCodeValue").Append(separator); //2
            sb.Append("Latitude").Append(separator); //3
            sb.Append("Longitude").Append(separator);  //4
            sb.Append("NAACCRGISCoordinateQualityCode").Append(separator);  //5
            sb.Append("NAACCRGISCoordinateQualityName").Append(separator); //6
            sb.Append("MatchScore").Append(separator); //7
            sb.Append("MatchType").Append(separator); //8
            sb.Append("FeatureMatchingGeographyType").Append(separator); //9
            sb.Append("RegionSize").Append(separator); //10
            sb.Append("RegionSizeUnits").Append(separator); //11
            sb.Append("InterpolationType").Append(separator); //12
            sb.Append("InterpolationSubType").Append(separator); //13
            sb.Append("MatchedLocationType").Append(separator); //14
            sb.Append("FeatureMatchingResultType").Append(separator); //15
            sb.Append("FeatureMatchingResultCount").Append(separator); //16
            sb.Append("FeatureMatchingResultTypeNotes").Append(separator); //17
            sb.Append("FeatureMatchingResultTypeTieBreakingNotes").Append(separator); //18
            sb.Append("TieHandlingStrategyType").Append(separator); //19
            sb.Append("FeatureMatchingSelectionMethod").Append(separator); //20
            sb.Append("FeatureMatchingSelectionMethodNotes").Append(separator); //21
            sb.Append("TimeTaken").Append(separator); //22

            sb.Append("CensusYear").Append(separator); //23
            sb.Append("NAACCRCensusTractCertaintyCode").Append(separator); //24
            sb.Append("NAACCRCensusTractCertaintyName").Append(separator); //25
            sb.Append("CensusBlock").Append(separator); //26
            sb.Append("CensusBlockGroup").Append(separator); //27
            sb.Append("CensusTract").Append(separator); //28
            sb.Append("CensusCountyFips").Append(separator); //29
            sb.Append("CensusCbsaFips").Append(separator); //30
            sb.Append("CensusCbsaMicro").Append(separator); //31
            sb.Append("CensusMcdFips").Append(separator); //32
            sb.Append("CensusMetDivFips").Append(separator); //33
            sb.Append("CensusMsaFips").Append(separator); //34
            sb.Append("CensusPlaceFips").Append(separator); //35
            sb.Append("CensusStateFips").Append(separator); //36

            sb.Append("MNumber").Append(separator); //37
            sb.Append("MNumberFractional").Append(separator); //38
            sb.Append("MPreDirectional").Append(separator); //39
            sb.Append("MPreQualifier").Append(separator); //40
            sb.Append("MPreType").Append(separator); //41
            sb.Append("MPreArticle").Append(separator); //42
            sb.Append("MName").Append(separator); //43
            sb.Append("MPostArticle").Append(separator); //44
            sb.Append("MPostQualifier").Append(separator); //45
            sb.Append("MSuffix").Append(separator); //46
            sb.Append("MPostDirectional").Append(separator); //47
            sb.Append("MSuiteType").Append(separator); //48
            sb.Append("MSuiteNumber").Append(separator); //49
            sb.Append("MPostOfficeBoxType").Append(separator); //50
            sb.Append("MPostOfficeBoxNumber").Append(separator); //51
            sb.Append("MCity").Append(separator); //52
            sb.Append("MConsolidatedCity").Append(separator); //53
            sb.Append("MMinorCivilDivision").Append(separator); //54
            sb.Append("MCountySubRegion").Append(separator); //55
            sb.Append("MCounty").Append(separator); //56
            sb.Append("MState").Append(separator); //57
            sb.Append("MZip").Append(separator); //58
            sb.Append("MZipPlus1").Append(separator); //59
            sb.Append("MZipPlus2").Append(separator); //60
            sb.Append("MZipPlus3").Append(separator); //61
            sb.Append("MZipPlus4").Append(separator); //62
            sb.Append("MZipPlus5").Append(separator); //63

            sb.Append("PNumber").Append(separator); //64
            sb.Append("PNumberFractional").Append(separator); //65
            sb.Append("PPreDirectional").Append(separator); //66
            sb.Append("PPreQualifier").Append(separator); //67
            sb.Append("PPreType").Append(separator); //68
            sb.Append("PPreArticle").Append(separator); //69
            sb.Append("PName").Append(separator); //70
            sb.Append("PPostArticle").Append(separator); //71
            sb.Append("PPostQualifier").Append(separator); //72
            sb.Append("PSuffix").Append(separator); //73
            sb.Append("PPostDirectional").Append(separator); //74
            sb.Append("PSuiteType").Append(separator); //75
            sb.Append("PSuiteNumber").Append(separator); //76
            sb.Append("PPostOfficeBoxType").Append(separator); //77
            sb.Append("PPostOfficeBoxNumber").Append(separator); //78
            sb.Append("PCity").Append(separator); //79
            sb.Append("PConsolidatedCity").Append(separator); //80
            sb.Append("PMinorCivilDivision").Append(separator); //81
            sb.Append("PCountySubRegion").Append(separator); //82
            sb.Append("PCounty").Append(separator); //83
            sb.Append("PState").Append(separator); //84
            sb.Append("PZip").Append(separator); //85
            sb.Append("PZipPlus1").Append(separator); //86
            sb.Append("PZipPlus2").Append(separator); //87
            sb.Append("PZipPlus3").Append(separator); //88
            sb.Append("PZipPlus4").Append(separator); //89
            sb.Append("PZipPlus5").Append(separator); //90

            sb.Append("FNumber").Append(separator); //91
            sb.Append("FNumberFractional").Append(separator); //92
            sb.Append("FPreDirectional").Append(separator); //93
            sb.Append("FPreQualifier").Append(separator); //94
            sb.Append("FPreType").Append(separator); //95
            sb.Append("FPreArticle").Append(separator); //96
            sb.Append("FName").Append(separator); //97
            sb.Append("FPostArticle").Append(separator); //98
            sb.Append("FPostQualifier").Append(separator); //99
            sb.Append("FSuffix").Append(separator); //100
            sb.Append("FPostDirectional").Append(separator); //101
            sb.Append("FSuiteType").Append(separator); //102
            sb.Append("FSuiteNumber").Append(separator); //103
            sb.Append("FPostOfficeBoxType").Append(separator); //104
            sb.Append("FPostOfficeBoxNumber").Append(separator); //105
            sb.Append("FCity").Append(separator); //106
            sb.Append("FConsolidatedCity").Append(separator); //107
            sb.Append("FMinorCivilDivision").Append(separator); //108
            sb.Append("FCountySubRegion").Append(separator); //109
            sb.Append("FCounty").Append(separator); //110
            sb.Append("FState").Append(separator); //111
            sb.Append("FZip").Append(separator); //112
            sb.Append("FZipPlus1").Append(separator); //113
            sb.Append("FZipPlus2").Append(separator); //114
            sb.Append("FZipPlus3").Append(separator); //115
            sb.Append("FZipPlus4").Append(separator); //116
            sb.Append("FZipPlus5").Append(separator); //117
            sb.Append("FArea").Append(separator); //118
            sb.Append("FAreaType").Append(separator); //119
            sb.Append("FGeometrySRID").Append(separator); //120
            sb.Append("FGeometry").Append(separator); //121
            sb.Append("FSource").Append(separator); //122
            sb.Append("FVintage").Append(separator); //123
            sb.Append("FPrimaryIdField").Append(separator); //124
            sb.Append("FPrimaryIdValue").Append(separator); //125
            sb.Append("FSecondaryIdField").Append(separator); //126
            sb.Append("FSecondaryIdValue"); //127

            return sb.ToString();
        }
        

        // added:    CensusYear
        // replaced: Census2000 fields with Census fields (removed the 2000)

        public string AsStringVerbose_V02_96(string separator, double version)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(TransactionId).Append(separator); //0
            sb.Append(Version).Append(separator); //1
            sb.Append(QueryStatusCodeValue).Append(separator); //2
            sb.Append(Latitude).Append(separator); //3
            sb.Append(Longitude).Append(separator);  //4
            sb.Append(MatchScore).Append(separator); //5
            sb.Append(MatchType).Append(separator); //6
            sb.Append(FeatureMatchingGeographyType).Append(separator); //7
            sb.Append(InterpolationType).Append(separator); //8
            sb.Append(InterpolationSubType).Append(separator); //9
            sb.Append(MatchedLocationType).Append(separator); //10
            sb.Append(FeatureMatchingResultType).Append(separator); //11
            sb.Append(FeatureMatchingResultCount).Append(separator); //12
            sb.Append(FeatureMatchingResultTypeNotes).Append(separator); //13
            sb.Append(FeatureMatchingResultTypeTieBreakingNotes).Append(separator); //14
            sb.Append(TieHandlingStrategyType).Append(separator); //15
            sb.Append(FeatureMatchingSelectionMethod).Append(separator); //16
            sb.Append(FeatureMatchingSelectionMethodNotes).Append(separator); //17
            sb.Append(TimeTaken).Append(separator); //18

            sb.Append(CensusYear).Append(separator); //19
            sb.Append(CensusBlock).Append(separator); //20
            sb.Append(CensusBlockGroup).Append(separator); //21
            sb.Append(CensusTract).Append(separator); //22
            sb.Append(CensusCountyFips).Append(separator); //23
            sb.Append(CensusCbsaFips).Append(separator); //24
            sb.Append(CensusCbsaMicro).Append(separator); //25
            sb.Append(CensusMcdFips).Append(separator); //26
            sb.Append(CensusMetDivFips).Append(separator); //27
            sb.Append(CensusMsaFips).Append(separator); //28
            sb.Append(CensusPlaceFips).Append(separator); //29
            sb.Append(CensusStateFips).Append(separator); //30

            sb.Append(MNumber).Append(separator); //31
            sb.Append(MNumberFractional).Append(separator); //32
            sb.Append(MPreDirectional).Append(separator); //33
            sb.Append(MPreQualifier).Append(separator); //34
            sb.Append(MPreType).Append(separator); //35
            sb.Append(MPreArticle).Append(separator); //36
            sb.Append(MName).Append(separator); //37
            sb.Append(MPostArticle).Append(separator); //38
            sb.Append(MPostQualifier).Append(separator); //39
            sb.Append(MSuffix).Append(separator); //40
            sb.Append(MPostDirectional).Append(separator); //41
            sb.Append(MSuiteType).Append(separator); //42
            sb.Append(MSuiteNumber).Append(separator); //43
            sb.Append(MPostOfficeBoxType).Append(separator); //44
            sb.Append(MPostOfficeBoxNumber).Append(separator); //45
            sb.Append(MCity).Append(separator); //46
            sb.Append(MConsolidatedCity).Append(separator); //47
            sb.Append(MMinorCivilDivision).Append(separator); //48
            sb.Append(MCountySubRegion).Append(separator); //49
            sb.Append(MCounty).Append(separator); //50
            sb.Append(MState).Append(separator); //51
            sb.Append(MZip).Append(separator); //52
            sb.Append(MZipPlus1).Append(separator); //53
            sb.Append(MZipPlus2).Append(separator); //54
            sb.Append(MZipPlus3).Append(separator); //55
            sb.Append(MZipPlus4).Append(separator); //56
            sb.Append(MZipPlus5).Append(separator); //57

            sb.Append(PNumber).Append(separator); //
            sb.Append(PNumberFractional).Append(separator); //
            sb.Append(PPreDirectional).Append(separator); //
            sb.Append(PPreQualifier).Append(separator); //
            sb.Append(PPreType).Append(separator); //
            sb.Append(PPreArticle).Append(separator); //
            sb.Append(PName).Append(separator); //
            sb.Append(PPostArticle).Append(separator); //
            sb.Append(PPostQualifier).Append(separator); //
            sb.Append(PSuffix).Append(separator); //
            sb.Append(PPostDirectional).Append(separator); //
            sb.Append(PSuiteType).Append(separator); //
            sb.Append(PSuiteNumber).Append(separator); //
            sb.Append(PPostOfficeBoxType).Append(separator); //
            sb.Append(PPostOfficeBoxNumber).Append(separator); //
            sb.Append(PCity).Append(separator); //
            sb.Append(PConsolidatedCity).Append(separator); //
            sb.Append(PMinorCivilDivision).Append(separator); //
            sb.Append(PCountySubRegion).Append(separator); //
            sb.Append(PCounty).Append(separator); //
            sb.Append(PState).Append(separator); //
            sb.Append(PZip).Append(separator); //
            sb.Append(PZipPlus1).Append(separator); //
            sb.Append(PZipPlus2).Append(separator); //
            sb.Append(PZipPlus3).Append(separator); //
            sb.Append(PZipPlus4).Append(separator); //
            sb.Append(PZipPlus5).Append(separator); //

            sb.Append(FNumber).Append(separator); //
            sb.Append(FNumberFractional).Append(separator); //
            sb.Append(FPreDirectional).Append(separator); //
            sb.Append(FPreQualifier).Append(separator); //
            sb.Append(FPreType).Append(separator); //
            sb.Append(FPreArticle).Append(separator); //
            sb.Append(FName).Append(separator); //
            sb.Append(FPostArticle).Append(separator); //
            sb.Append(FPostQualifier).Append(separator); //
            sb.Append(FSuffix).Append(separator); //
            sb.Append(FPostDirectional).Append(separator); //
            sb.Append(FSuiteType).Append(separator); //
            sb.Append(FSuiteNumber).Append(separator); //
            sb.Append(FPostOfficeBoxType).Append(separator); //
            sb.Append(FPostOfficeBoxNumber).Append(separator); //
            sb.Append(FCity).Append(separator); //
            sb.Append(FConsolidatedCity).Append(separator); //
            sb.Append(FMinorCivilDivision).Append(separator); //
            sb.Append(FCountySubRegion).Append(separator); //
            sb.Append(FCounty).Append(separator); //
            sb.Append(FState).Append(separator); //
            sb.Append(FZip).Append(separator); //
            sb.Append(FZipPlus1).Append(separator); //
            sb.Append(FZipPlus2).Append(separator); //
            sb.Append(FZipPlus3).Append(separator); //
            sb.Append(FZipPlus4).Append(separator); //
            sb.Append(FZipPlus5).Append(separator); //
            sb.Append(FArea).Append(separator); //
            sb.Append(FAreaType).Append(separator); //

            sb.Append(FGeometrySRID).Append(separator); //
            if (String.Compare(separator, ",", true) == 0)
            {
                sb.Append(FGeometry.Replace(separator, ";")).Append(separator); //
            }
            else
            {
                sb.Append(FGeometry).Append(separator); //
            }

            sb.Append(FSource).Append(separator); //
            sb.Append(FVintage).Append(separator); //
            sb.Append(FPrimaryIdField).Append(separator); //
            sb.Append(FPrimaryIdValue).Append(separator); //
            sb.Append(FSecondaryIdField).Append(separator); //
            sb.Append(FSecondaryIdValue); //

            return sb.ToString();
        }

        public override string ToString()
        {
            return ToString(false);
        }

        public string ToString(bool verbose)
        {
            StringBuilder ret = new StringBuilder();
            if (!verbose)
            {
                ret.AppendFormat("{0}", Longitude);
                ret.Append(",");
                ret.AppendFormat("{0}", Latitude);
                ret.Append(",");
                ret.AppendFormat("{0}", Quality);
                ret.Append(",");
                ret.AppendFormat("{0}", MatchedLocationType);
                ret.Append(",");
                ret.AppendFormat("{0}", MatchType);
                ret.Append(",");
                ret.AppendFormat("{0}", QueryStatusCodes);
            }

            return ret.ToString();
        }

    }
}
