using System;
using System.Text;
using System.Xml.Serialization;
using USC.GISResearchLab.AddressProcessing.Core.AddressNormalization.Implementations;
using USC.GISResearchLab.Census.Core.Configurations.ServerConfigurations;
using USC.GISResearchLab.Common.Core.Geocoders.FeatureMatching;
using USC.GISResearchLab.Core.WebServices.ResultCodes;
using USC.GISResearchLab.Geocoding.Core.Algorithms.FeatureInterpolationMethods;
using USC.GISResearchLab.Geocoding.Core.Algorithms.TieHandlingMethods;
using USC.GISResearchLab.Geocoding.Core.Metadata;
using USC.GISResearchLab.Geocoding.Core.Metadata.FeatureMatchingResults;
using USC.GISResearchLab.Geocoding.Core.Metadata.Qualities;

namespace USC.GISResearchLab.Geocoding.Core.OutputData.WebServices
{

    //this class is deprecated because we want to be able to return a 200, 1990, and 2010 census values which are hard coded in this class
    //use WebServiceGeocodeQueryResult instead

    [Serializable]
    public class WebServiceGeocodeResult
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
        public FeatureMatchingGeographyType FeatureMatchingGeographyType { get; set; }
        public FeatureMatchingResultType FeatureMatchingResultType { get; set; }
        public double MatchScore { get; set; }
        public InterpolationType InterpolationType { get; set; }
        public InterpolationSubType InterpolationSubType { get; set; }

        [XmlIgnore]
        public GeocodeStatistics Statistics { get; set; }

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

        public string ErrorMessage { get; set; }
        public string TimeTaken { get; set; }

        #region Census Fields

        // these fields are deprecated because we want to be able to return a 200, 1990, and 2010 census values
        public double Census2000TimeTaken { get; set; }
        public string Census2000StateFips { get; set; }
        public string Census2000CountyFips { get; set; }
        public string Census2000Tract { get; set; }
        public string Census2000BlockGroup { get; set; }
        public string Census2000Block { get; set; }
        public string Census2000PlaceFips { get; set; }
        public string Census2000McdFips { get; set; }
        public string Census2000MsaFips { get; set; }
        public string Census2000MetDivFips { get; set; }
        public string Census2000CbsaFips { get; set; }
        public string Census2000CbsaMicro { get; set; }


        // use these ones instead
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

        public WebServiceGeocodeResult()
            : this(new AddressNormalizer().AddressParserVersion)
        {
        }

        public WebServiceGeocodeResult(double version)
        {
            QueryStatusCodes = QueryStatusCodes.Unknown;
            TransactionId = "";
            Latitude = 0.0;
            Longitude = 0.0;
            MatchedLocationType = "";
            MatchType = "";
            Quality = "";
            ErrorMessage = "";

            FeatureMatchingResultCount = "";
            FeatureMatchingResultTypeNotes = "";
            FeatureMatchingResultTypeTieBreakingNotes = "";
            FeatureMatchingSelectionMethodNotes = "";

            Census2000Block = "";
            Census2000BlockGroup = "";
            Census2000CbsaFips = "";
            Census2000CbsaMicro = "";
            Census2000CountyFips = "";
            Census2000PlaceFips = "";
            Census2000McdFips = "";
            Census2000MetDivFips = "";
            Census2000MsaFips = "";
            Census2000StateFips = "";
            Census2000Tract = "";

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
            if (version <= 2.93)
            {
                ret = AsString_V02_93(separator);
            }
            else if (version >= 2.94)
            {
                ret = AsString_V02_94(separator);
            }
            return ret;
        }

        public string AsString_V02_93(string separator)
        {
            string ret = "";
            ret += TransactionId + separator;
            ret += QueryStatusCodeValue + separator;
            ret += QueryStatusCodeName + separator;
            ret += Latitude + separator;
            ret += Longitude + separator;
            ret += Quality + separator;
            ret += MatchedLocationType + separator;
            ret += MatchType + separator;
            ret += TimeTaken;


            return ret;
        }

        public string AsString_V02_94(string separator)
        {
            string ret = "";
            ret += TransactionId + separator;
            ret += Version + separator;
            ret += QueryStatusCodeValue + separator;
            ret += Latitude + separator;
            ret += Longitude + separator;
            ret += MatchScore + separator;
            ret += MatchType + separator;
            ret += FeatureMatchingGeographyType + separator;
            ret += InterpolationType + separator;
            ret += InterpolationSubType + separator;
            ret += MatchedLocationType + separator;
            ret += FeatureMatchingResultType + separator;
            ret += TimeTaken;

            return ret;
        }

        public string AsStringVerbose(string separator)
        {
            return AsStringVerbose(separator, Version);
        }

        public string AsStringVerbose(string separator, double version)
        {
            string ret = null;
            if (version < 2.6)
            {
                ret = AsStringVerbose_Pre_V02_6(separator, version);
            }
            else
            {
                if (version == 2.6)
                {
                    ret = AsStringVerbose_V02_6(separator, version);
                }
                else if (version >= 2.7 && version < 2.91)
                {
                    ret = AsStringVerbose_V02_7(separator, version);
                }
                else if (version == 2.91)
                {
                    ret = AsStringVerbose_V02_91(separator, version);
                }
                else if (version == 2.92)
                {
                    ret = AsStringVerbose_V02_92(separator, version);
                }
                else if (version == 2.93)
                {
                    ret = AsStringVerbose_V02_93(separator, version);
                }
                else if (version == 2.94)
                {
                    ret = AsStringVerbose_V02_94(separator, version);
                }
                else if (version == 2.95)
                {
                    ret = AsStringVerbose_V02_95(separator, version);
                }
                else if (version >= 2.96)
                {
                    ret = AsStringVerbose_V02_96(separator, version);
                }
                else
                {
                    throw new Exception("Unsupported or unimplemented version number: " + version);
                }
            }
            return ret;
        }

        public string AsStringVerbose_Pre_V02_6(string separator, double version)
        {
            string ret = "";
            ret += TransactionId + separator;
            ret += QueryStatusCodeValue + separator;
            ret += QueryStatusCodeName + separator;
            ret += Latitude + separator;
            ret += Longitude + separator;
            ret += Quality + separator;
            ret += MatchType + separator;
            ret += TimeTaken + separator;
            ret += MNumber + separator;
            ret += MPreDirectional + separator;
            ret += MName + separator;
            ret += MSuffix + separator;
            ret += MPreDirectional + separator;
            ret += MCity + separator;
            ret += MState + separator;
            ret += MZip + separator;
            ret += PNumber + separator;
            ret += PPreDirectional + separator;
            ret += PName + separator;
            ret += PSuffix + separator;
            ret += PPostDirectional + separator;
            ret += PPostOfficeBoxType + separator;
            ret += PPostOfficeBoxNumber + separator;
            ret += PCity + separator;
            ret += PState + separator;
            ret += PZip + separator;
            ret += PZipPlus2 + separator;
            ret += PZipPlus3 + separator;
            ret += PZipPlus4 + separator;
            ret += PZipPlus5 + separator;
            ret += FNumber + separator;
            ret += FPreDirectional + separator;
            ret += FName + separator;
            ret += FSuffix + separator;
            ret += FPostDirectional + separator;
            ret += FCity + separator;
            ret += FState + separator;
            ret += FZip + separator;

            return ret;
        }

        // added in 
        // Matched attributes -- MNumberFractional, MSuiteType, MSuiteNumber, MPostOfficeBoxType, MPostOfficeBoxType, MZipPlus2, MZipPlus3, MZipPlus4, MZipPlus5
        // Parsed attributes -- PNumberFractional, PSuiteType, PSuiteNumber
        // Census attributes -- Census2000Block, Census2000BlockGroup, Census2000Tract, Census2000CountyFips. Census2000StateFips
        public string AsStringVerbose_V02_6(string separator, double version)
        {
            string ret = "";
            ret += TransactionId + separator;
            ret += QueryStatusCodeValue + separator;
            ret += QueryStatusCodeName + separator;
            ret += Latitude + separator;
            ret += Longitude + separator;
            ret += Quality + separator;
            ret += MatchType + separator;
            ret += TimeTaken + separator;

            ret += Census2000Block + separator;
            ret += Census2000BlockGroup + separator;
            ret += Census2000Tract + separator;
            ret += Census2000CountyFips + separator;
            ret += Census2000StateFips + separator;

            ret += MNumber + separator;
            ret += MNumberFractional + separator;
            ret += MPreDirectional + separator;
            ret += MName + separator;
            ret += MSuffix + separator;
            ret += MPostDirectional + separator;
            ret += MSuiteType + separator;
            ret += MSuiteNumber + separator;
            ret += MPostOfficeBoxType + separator;
            ret += MPostOfficeBoxNumber + separator;
            ret += MCity + separator;
            ret += MState + separator;
            ret += MZip + separator;
            ret += MZipPlus2 + separator;
            ret += MZipPlus3 + separator;
            ret += MZipPlus4 + separator;
            ret += MZipPlus5 + separator;

            ret += PNumber + separator;
            ret += PNumberFractional + separator;
            ret += PPreDirectional + separator;
            ret += PName + separator;
            ret += PSuffix + separator;
            ret += PPostDirectional + separator;
            ret += PSuiteType + separator;
            ret += PSuiteNumber + separator;
            ret += PPostOfficeBoxType + separator;
            ret += PPostOfficeBoxNumber + separator;
            ret += PCity + separator;
            ret += PState + separator;
            ret += PZip + separator;
            ret += PZipPlus2 + separator;
            ret += PZipPlus3 + separator;
            ret += PZipPlus4 + separator;
            ret += PZipPlus5 + separator;

            ret += FNumber + separator;
            ret += FPreDirectional + separator;
            ret += FName + separator;
            ret += FSuffix + separator;
            ret += FPostDirectional + separator;
            ret += FCity + separator;
            ret += FState + separator;
            ret += FZip;

            return ret;
        }

        // added in 
        // MatchedLocationType (street address, PO Box, intersection, etc.)
        public string AsStringVerbose_V02_7(string separator, double version)
        {
            string ret = "";
            ret += TransactionId + separator;
            ret += QueryStatusCodeValue + separator;
            ret += QueryStatusCodeName + separator;
            ret += Latitude + separator;
            ret += Longitude + separator;
            ret += Quality + separator;
            ret += MatchedLocationType + separator;
            ret += MatchType + separator;
            ret += TimeTaken + separator;

            ret += Census2000Block + separator;
            ret += Census2000BlockGroup + separator;
            ret += Census2000Tract + separator;
            ret += Census2000CountyFips + separator;
            ret += Census2000StateFips + separator;

            ret += MNumber + separator;
            ret += MNumberFractional + separator;
            ret += MPreDirectional + separator;
            ret += MName + separator;
            ret += MSuffix + separator;
            ret += MPostDirectional + separator;
            ret += MSuiteType + separator;
            ret += MSuiteNumber + separator;
            ret += MPostOfficeBoxType + separator;
            ret += MPostOfficeBoxNumber + separator;
            ret += MCity + separator;
            ret += MState + separator;
            ret += MZip + separator;
            ret += MZipPlus2 + separator;
            ret += MZipPlus3 + separator;
            ret += MZipPlus4 + separator;
            ret += MZipPlus5 + separator;

            ret += PNumber + separator;
            ret += PNumberFractional + separator;
            ret += PPreDirectional + separator;
            ret += PName + separator;
            ret += PSuffix + separator;
            ret += PPostDirectional + separator;
            ret += PSuiteType + separator;
            ret += PSuiteNumber + separator;
            ret += PPostOfficeBoxType + separator;
            ret += PPostOfficeBoxNumber + separator;
            ret += PCity + separator;
            ret += PState + separator;
            ret += PZip + separator;
            ret += PZipPlus2 + separator;
            ret += PZipPlus3 + separator;
            ret += PZipPlus4 + separator;
            ret += PZipPlus5 + separator;

            ret += FNumber + separator;
            ret += FPreDirectional + separator;
            ret += FName + separator;
            ret += FSuffix + separator;
            ret += FPostDirectional + separator;
            ret += FCity + separator;
            ret += FState + separator;
            ret += FZip;

            return ret;
        }

        // added in 
        // qualifiers, zipPlus1, mcd, concity, county, countysub, f_source, f_vintage, f_area, f_areaType, f_geometry
        public string AsStringVerbose_V02_91(string separator, double version)
        {
            string ret = "";
            ret += TransactionId + separator;
            ret += QueryStatusCodeValue + separator;
            ret += QueryStatusCodeName + separator;
            ret += Latitude + separator;
            ret += Longitude + separator;
            ret += Quality + separator;
            ret += MatchedLocationType + separator;
            ret += MatchType + separator;
            ret += TimeTaken + separator;

            ret += Census2000Block + separator;
            ret += Census2000BlockGroup + separator;
            ret += Census2000Tract + separator;
            ret += Census2000CountyFips + separator;
            ret += Census2000StateFips + separator;

            ret += MNumber + separator;
            ret += MNumberFractional + separator;
            ret += MPreDirectional + separator;
            ret += MPreQualifier + separator;
            ret += MName + separator;
            ret += MPostQualifier + separator;
            ret += MSuffix + separator;
            ret += MPostDirectional + separator;
            ret += MSuiteType + separator;
            ret += MSuiteNumber + separator;
            ret += MPostOfficeBoxType + separator;
            ret += MPostOfficeBoxNumber + separator;
            ret += MCity + separator;
            ret += MConsolidatedCity + separator;
            ret += MMinorCivilDivision + separator;
            ret += MCountySubRegion + separator;
            ret += MCounty + separator;
            ret += MState + separator;
            ret += MZip + separator;
            ret += MZipPlus1 + separator;
            ret += MZipPlus2 + separator;
            ret += MZipPlus3 + separator;
            ret += MZipPlus4 + separator;
            ret += MZipPlus5 + separator;

            ret += PNumber + separator;
            ret += PNumberFractional + separator;
            ret += PPreDirectional + separator;
            ret += PPreQualifier + separator;
            ret += PName + separator;
            ret += PPostQualifier + separator;
            ret += PSuffix + separator;
            ret += PPostDirectional + separator;
            ret += PSuiteType + separator;
            ret += PSuiteNumber + separator;
            ret += PPostOfficeBoxType + separator;
            ret += PPostOfficeBoxNumber + separator;
            ret += PCity + separator;
            ret += PConsolidatedCity + separator;
            ret += PMinorCivilDivision + separator;
            ret += PCountySubRegion + separator;
            ret += PCounty + separator;
            ret += PState + separator;
            ret += PZip + separator;
            ret += PZipPlus1 + separator;
            ret += PZipPlus2 + separator;
            ret += PZipPlus3 + separator;
            ret += PZipPlus4 + separator;
            ret += PZipPlus5 + separator;

            ret += FNumber + separator;
            ret += FNumberFractional + separator;
            ret += FPreDirectional + separator;
            ret += FPreQualifier + separator;
            ret += FName + separator;
            ret += FPostQualifier + separator;
            ret += FSuffix + separator;
            ret += FPostDirectional + separator;
            ret += FSuiteType + separator;
            ret += FSuiteNumber + separator;
            ret += FPostOfficeBoxType + separator;
            ret += FPostOfficeBoxNumber + separator;
            ret += FCity + separator;
            ret += FConsolidatedCity + separator;
            ret += FMinorCivilDivision + separator;
            ret += FCountySubRegion + separator;
            ret += FCounty + separator;
            ret += FState + separator;
            ret += FZip + separator;
            ret += FZipPlus1 + separator;
            ret += FZipPlus2 + separator;
            ret += FZipPlus3 + separator;
            ret += FZipPlus4 + separator;
            ret += FZipPlus5 + separator;
            ret += FArea + separator;
            ret += FAreaType + separator;
            ret += FGeometry + separator;
            ret += FSource + separator;
            ret += FVintage + separator;
            ret += FPrimaryIdField + separator;
            ret += FPrimaryIdValue + separator;
            ret += FSecondaryIdField + separator;
            ret += FSecondaryIdValue;

            return ret;
        }

        // added: version, match score, geocodeQualityType, FeatureMatchingGeographyType, FeatureMatchingResultType, InterpolationType, InterpolationSubType
        // removed: QueryStatusCodeName, Quality
        public string AsStringVerbose_V02_92(string separator, double version)
        {
            string ret = "";
            ret += TransactionId + separator;
            ret += Version + separator;
            ret += QueryStatusCodeValue + separator;

            ret += Latitude + separator;
            ret += Longitude + separator;

            ret += MatchScore + separator;
            //ret += GeocodeQualityType + separator;
            ret += MatchType + separator;
            ret += FeatureMatchingGeographyType + separator;
            ret += InterpolationType + separator;
            ret += InterpolationSubType + separator;
            ret += MatchedLocationType + separator;
            ret += FeatureMatchingResultType + separator;

            ret += Census2000Block + separator;
            ret += Census2000BlockGroup + separator;
            ret += Census2000Tract + separator;
            ret += Census2000CountyFips + separator;
            ret += Census2000StateFips + separator;

            ret += MNumber + separator;
            ret += MNumberFractional + separator;
            ret += MPreDirectional + separator;
            ret += MPreQualifier + separator;
            ret += MName + separator;
            ret += MPostQualifier + separator;
            ret += MSuffix + separator;
            ret += MPostDirectional + separator;
            ret += MSuiteType + separator;
            ret += MSuiteNumber + separator;
            ret += MPostOfficeBoxType + separator;
            ret += MPostOfficeBoxNumber + separator;
            ret += MCity + separator;
            ret += MConsolidatedCity + separator;
            ret += MMinorCivilDivision + separator;
            ret += MCountySubRegion + separator;
            ret += MCounty + separator;
            ret += MState + separator;
            ret += MZip + separator;
            ret += MZipPlus1 + separator;
            ret += MZipPlus2 + separator;
            ret += MZipPlus3 + separator;
            ret += MZipPlus4 + separator;
            ret += MZipPlus5 + separator;

            ret += PNumber + separator;
            ret += PNumberFractional + separator;
            ret += PPreDirectional + separator;
            ret += PPreQualifier + separator;
            ret += PName + separator;
            ret += PPostQualifier + separator;
            ret += PSuffix + separator;
            ret += PPostDirectional + separator;
            ret += PSuiteType + separator;
            ret += PSuiteNumber + separator;
            ret += PPostOfficeBoxType + separator;
            ret += PPostOfficeBoxNumber + separator;
            ret += PCity + separator;
            ret += PConsolidatedCity + separator;
            ret += PMinorCivilDivision + separator;
            ret += PCountySubRegion + separator;
            ret += PCounty + separator;
            ret += PState + separator;
            ret += PZip + separator;
            ret += PZipPlus1 + separator;
            ret += PZipPlus2 + separator;
            ret += PZipPlus3 + separator;
            ret += PZipPlus4 + separator;
            ret += PZipPlus5 + separator;

            ret += FNumber + separator;
            ret += FNumberFractional + separator;
            ret += FPreDirectional + separator;
            ret += FPreQualifier + separator;
            ret += FName + separator;
            ret += FPostQualifier + separator;
            ret += FSuffix + separator;
            ret += FPostDirectional + separator;
            ret += FSuiteType + separator;
            ret += FSuiteNumber + separator;
            ret += FPostOfficeBoxType + separator;
            ret += FPostOfficeBoxNumber + separator;
            ret += FCity + separator;
            ret += FConsolidatedCity + separator;
            ret += FMinorCivilDivision + separator;
            ret += FCountySubRegion + separator;
            ret += FCounty + separator;
            ret += FState + separator;
            ret += FZip + separator;
            ret += FZipPlus1 + separator;
            ret += FZipPlus2 + separator;
            ret += FZipPlus3 + separator;
            ret += FZipPlus4 + separator;
            ret += FZipPlus5 + separator;
            ret += FArea + separator;
            ret += FAreaType + separator;
            ret += FGeometry + separator;
            ret += FSource + separator;
            ret += FVintage + separator;
            ret += FPrimaryIdField + separator;
            ret += FPrimaryIdValue + separator;
            ret += FSecondaryIdField + separator;
            ret += FSecondaryIdValue;

            return ret;
        }

        // added: Census2000CbsaFips,  Census2000CbsaMicro, Census2000McdFips, Census2000MetDivFips, Census2000MsaFips, Census2000PlaceFips
        // updated: census block group to be first char of block, census block to be the correct block value (what used to be blockgroup)
        public string AsStringVerbose_V02_93(string separator, double version)
        {
            string ret = "";
            ret += TransactionId + separator;
            ret += Version + separator;
            ret += QueryStatusCodeValue + separator;

            ret += Latitude + separator;
            ret += Longitude + separator;

            ret += MatchScore + separator;
            //ret += GeocodeQualityType + separator;
            ret += MatchType + separator;
            ret += FeatureMatchingGeographyType + separator;
            ret += InterpolationType + separator;
            ret += InterpolationSubType + separator;
            ret += MatchedLocationType + separator;
            ret += FeatureMatchingResultType + separator;

            ret += Census2000Block + separator;
            ret += Census2000BlockGroup + separator;
            ret += Census2000Tract + separator;
            ret += Census2000PlaceFips + separator;
            ret += Census2000CbsaFips + separator;
            ret += Census2000CbsaMicro + separator;
            ret += Census2000McdFips + separator;
            ret += Census2000MetDivFips + separator;
            ret += Census2000MsaFips + separator;
            ret += Census2000CountyFips + separator;
            ret += Census2000StateFips + separator;

            ret += MNumber + separator;
            ret += MNumberFractional + separator;
            ret += MPreDirectional + separator;
            ret += MPreQualifier + separator;
            ret += MName + separator;
            ret += MPostQualifier + separator;
            ret += MSuffix + separator;
            ret += MPostDirectional + separator;
            ret += MSuiteType + separator;
            ret += MSuiteNumber + separator;
            ret += MPostOfficeBoxType + separator;
            ret += MPostOfficeBoxNumber + separator;
            ret += MCity + separator;
            ret += MConsolidatedCity + separator;
            ret += MMinorCivilDivision + separator;
            ret += MCountySubRegion + separator;
            ret += MCounty + separator;
            ret += MState + separator;
            ret += MZip + separator;
            ret += MZipPlus1 + separator;
            ret += MZipPlus2 + separator;
            ret += MZipPlus3 + separator;
            ret += MZipPlus4 + separator;
            ret += MZipPlus5 + separator;

            ret += PNumber + separator;
            ret += PNumberFractional + separator;
            ret += PPreDirectional + separator;
            ret += PPreQualifier + separator;
            ret += PName + separator;
            ret += PPostQualifier + separator;
            ret += PSuffix + separator;
            ret += PPostDirectional + separator;
            ret += PSuiteType + separator;
            ret += PSuiteNumber + separator;
            ret += PPostOfficeBoxType + separator;
            ret += PPostOfficeBoxNumber + separator;
            ret += PCity + separator;
            ret += PConsolidatedCity + separator;
            ret += PMinorCivilDivision + separator;
            ret += PCountySubRegion + separator;
            ret += PCounty + separator;
            ret += PState + separator;
            ret += PZip + separator;
            ret += PZipPlus1 + separator;
            ret += PZipPlus2 + separator;
            ret += PZipPlus3 + separator;
            ret += PZipPlus4 + separator;
            ret += PZipPlus5 + separator;

            ret += FNumber + separator;
            ret += FNumberFractional + separator;
            ret += FPreDirectional + separator;
            ret += FPreQualifier + separator;
            ret += FName + separator;
            ret += FPostQualifier + separator;
            ret += FSuffix + separator;
            ret += FPostDirectional + separator;
            ret += FSuiteType + separator;
            ret += FSuiteNumber + separator;
            ret += FPostOfficeBoxType + separator;
            ret += FPostOfficeBoxNumber + separator;
            ret += FCity + separator;
            ret += FConsolidatedCity + separator;
            ret += FMinorCivilDivision + separator;
            ret += FCountySubRegion + separator;
            ret += FCounty + separator;
            ret += FState + separator;
            ret += FZip + separator;
            ret += FZipPlus1 + separator;
            ret += FZipPlus2 + separator;
            ret += FZipPlus3 + separator;
            ret += FZipPlus4 + separator;
            ret += FZipPlus5 + separator;
            ret += FArea + separator;
            ret += FAreaType + separator;
            ret += FGeometry + separator;
            ret += FSource + separator;
            ret += FVintage + separator;
            ret += FPrimaryIdField + separator;
            ret += FPrimaryIdValue + separator;
            ret += FSecondaryIdField + separator;
            ret += FSecondaryIdValue;

            return ret;
        }

        // added: PreArticles, PreTypes, PostArticles, geometrySrid
        // updated: census block group to be first char of block, census block to be the correct block value (what used to be blockgroup)
        public string AsStringVerbose_V02_94(string separator, double version)
        {
            string ret = "";
            ret += TransactionId + separator;
            ret += Version + separator;
            ret += QueryStatusCodeValue + separator;

            ret += Latitude + separator;
            ret += Longitude + separator;

            ret += MatchScore + separator;
            //ret += GeocodeQualityType + separator;
            ret += MatchType + separator;
            ret += FeatureMatchingGeographyType + separator;
            ret += InterpolationType + separator;
            ret += InterpolationSubType + separator;
            ret += MatchedLocationType + separator;
            ret += FeatureMatchingResultType + separator;
            ret += TimeTaken + separator;

            ret += Census2000Block + separator;
            ret += Census2000BlockGroup + separator;
            ret += Census2000Tract + separator;
            ret += Census2000CountyFips + separator;
            ret += Census2000CbsaFips + separator;
            ret += Census2000CbsaMicro + separator;
            ret += Census2000McdFips + separator;
            ret += Census2000MetDivFips + separator;
            ret += Census2000MsaFips + separator;
            ret += Census2000PlaceFips + separator;
            ret += Census2000StateFips + separator;

            ret += MNumber + separator;
            ret += MNumberFractional + separator;
            ret += MPreDirectional + separator;
            ret += MPreQualifier + separator;
            ret += MPreType + separator;
            ret += MPreArticle + separator;
            ret += MName + separator;
            ret += MPostArticle + separator;
            ret += MPostQualifier + separator;
            ret += MSuffix + separator;
            ret += MPostDirectional + separator;
            ret += MSuiteType + separator;
            ret += MSuiteNumber + separator;
            ret += MPostOfficeBoxType + separator;
            ret += MPostOfficeBoxNumber + separator;
            ret += MCity + separator;
            ret += MConsolidatedCity + separator;
            ret += MMinorCivilDivision + separator;
            ret += MCountySubRegion + separator;
            ret += MCounty + separator;
            ret += MState + separator;
            ret += MZip + separator;
            ret += MZipPlus1 + separator;
            ret += MZipPlus2 + separator;
            ret += MZipPlus3 + separator;
            ret += MZipPlus4 + separator;
            ret += MZipPlus5 + separator;

            ret += PNumber + separator;
            ret += PNumberFractional + separator;
            ret += PPreDirectional + separator;
            ret += PPreQualifier + separator;
            ret += PPreType + separator;
            ret += PPreArticle + separator;
            ret += PName + separator;
            ret += PPostArticle + separator;
            ret += PPostQualifier + separator;
            ret += PSuffix + separator;
            ret += PPostDirectional + separator;
            ret += PSuiteType + separator;
            ret += PSuiteNumber + separator;
            ret += PPostOfficeBoxType + separator;
            ret += PPostOfficeBoxNumber + separator;
            ret += PCity + separator;
            ret += PConsolidatedCity + separator;
            ret += PMinorCivilDivision + separator;
            ret += PCountySubRegion + separator;
            ret += PCounty + separator;
            ret += PState + separator;
            ret += PZip + separator;
            ret += PZipPlus1 + separator;
            ret += PZipPlus2 + separator;
            ret += PZipPlus3 + separator;
            ret += PZipPlus4 + separator;
            ret += PZipPlus5 + separator;

            ret += FNumber + separator;
            ret += FNumberFractional + separator;
            ret += FPreDirectional + separator;
            ret += FPreQualifier + separator;
            ret += FPreType + separator;
            ret += FPreArticle + separator;
            ret += FName + separator;
            ret += FPostArticle + separator;
            ret += FPostQualifier + separator;
            ret += FSuffix + separator;
            ret += FPostDirectional + separator;
            ret += FSuiteType + separator;
            ret += FSuiteNumber + separator;
            ret += FPostOfficeBoxType + separator;
            ret += FPostOfficeBoxNumber + separator;
            ret += FCity + separator;
            ret += FConsolidatedCity + separator;
            ret += FMinorCivilDivision + separator;
            ret += FCountySubRegion + separator;
            ret += FCounty + separator;
            ret += FState + separator;
            ret += FZip + separator;
            ret += FZipPlus1 + separator;
            ret += FZipPlus2 + separator;
            ret += FZipPlus3 + separator;
            ret += FZipPlus4 + separator;
            ret += FZipPlus5 + separator;
            ret += FArea + separator;
            ret += FAreaType + separator;

            ret += FGeometrySRID + separator;
            if (String.Compare(separator, ",", true) == 0)
            {
                ret += FGeometry.Replace(separator, ";") + separator;
            }
            else
            {
                ret += FGeometry + separator;
            }

            ret += FSource + separator;
            ret += FVintage + separator;
            ret += FPrimaryIdField + separator;
            ret += FPrimaryIdValue + separator;
            ret += FSecondaryIdField + separator;
            ret += FSecondaryIdValue;

            return ret;
        }

        // added:   FeatureMatchingResultCount,
        //          FeatureMatchingResultTypeNotes,
        //          FeatureMatchingResultTypeTieBreakingNotes,
        //          TieHandlingStrategyType,
        //          FeatureMatchingSelectionMethod,
        //          FeatureMatchingSelectionMethodNotes

        public string AsStringVerbose_V02_95(string separator, double version)
        {
            string ret = "";
            ret += TransactionId + separator;
            ret += Version + separator;
            ret += QueryStatusCodeValue + separator;
            ret += Latitude + separator;
            ret += Longitude + separator;
            ret += MatchScore + separator;
            ret += MatchType + separator;
            ret += FeatureMatchingGeographyType + separator;
            ret += InterpolationType + separator;
            ret += InterpolationSubType + separator;
            ret += MatchedLocationType + separator;
            ret += FeatureMatchingResultType + separator;
            ret += FeatureMatchingResultCount + separator;
            ret += FeatureMatchingResultTypeNotes + separator;
            ret += FeatureMatchingResultTypeTieBreakingNotes + separator;
            ret += TieHandlingStrategyType + separator;
            ret += FeatureMatchingSelectionMethod + separator;
            ret += FeatureMatchingSelectionMethodNotes + separator;
            ret += TimeTaken + separator;

            ret += Census2000Block + separator;
            ret += Census2000BlockGroup + separator;
            ret += Census2000Tract + separator;
            ret += Census2000CountyFips + separator;
            ret += Census2000CbsaFips + separator;
            ret += Census2000CbsaMicro + separator;
            ret += Census2000McdFips + separator;
            ret += Census2000MetDivFips + separator;
            ret += Census2000MsaFips + separator;
            ret += Census2000PlaceFips + separator;
            ret += Census2000StateFips + separator;

            ret += MNumber + separator;
            ret += MNumberFractional + separator;
            ret += MPreDirectional + separator;
            ret += MPreQualifier + separator;
            ret += MPreType + separator;
            ret += MPreArticle + separator;
            ret += MName + separator;
            ret += MPostArticle + separator;
            ret += MPostQualifier + separator;
            ret += MSuffix + separator;
            ret += MPostDirectional + separator;
            ret += MSuiteType + separator;
            ret += MSuiteNumber + separator;
            ret += MPostOfficeBoxType + separator;
            ret += MPostOfficeBoxNumber + separator;
            ret += MCity + separator;
            ret += MConsolidatedCity + separator;
            ret += MMinorCivilDivision + separator;
            ret += MCountySubRegion + separator;
            ret += MCounty + separator;
            ret += MState + separator;
            ret += MZip + separator;
            ret += MZipPlus1 + separator;
            ret += MZipPlus2 + separator;
            ret += MZipPlus3 + separator;
            ret += MZipPlus4 + separator;
            ret += MZipPlus5 + separator;

            ret += PNumber + separator;
            ret += PNumberFractional + separator;
            ret += PPreDirectional + separator;
            ret += PPreQualifier + separator;
            ret += PPreType + separator;
            ret += PPreArticle + separator;
            ret += PName + separator;
            ret += PPostArticle + separator;
            ret += PPostQualifier + separator;
            ret += PSuffix + separator;
            ret += PPostDirectional + separator;
            ret += PSuiteType + separator;
            ret += PSuiteNumber + separator;
            ret += PPostOfficeBoxType + separator;
            ret += PPostOfficeBoxNumber + separator;
            ret += PCity + separator;
            ret += PConsolidatedCity + separator;
            ret += PMinorCivilDivision + separator;
            ret += PCountySubRegion + separator;
            ret += PCounty + separator;
            ret += PState + separator;
            ret += PZip + separator;
            ret += PZipPlus1 + separator;
            ret += PZipPlus2 + separator;
            ret += PZipPlus3 + separator;
            ret += PZipPlus4 + separator;
            ret += PZipPlus5 + separator;

            ret += FNumber + separator;
            ret += FNumberFractional + separator;
            ret += FPreDirectional + separator;
            ret += FPreQualifier + separator;
            ret += FPreType + separator;
            ret += FPreArticle + separator;
            ret += FName + separator;
            ret += FPostArticle + separator;
            ret += FPostQualifier + separator;
            ret += FSuffix + separator;
            ret += FPostDirectional + separator;
            ret += FSuiteType + separator;
            ret += FSuiteNumber + separator;
            ret += FPostOfficeBoxType + separator;
            ret += FPostOfficeBoxNumber + separator;
            ret += FCity + separator;
            ret += FConsolidatedCity + separator;
            ret += FMinorCivilDivision + separator;
            ret += FCountySubRegion + separator;
            ret += FCounty + separator;
            ret += FState + separator;
            ret += FZip + separator;
            ret += FZipPlus1 + separator;
            ret += FZipPlus2 + separator;
            ret += FZipPlus3 + separator;
            ret += FZipPlus4 + separator;
            ret += FZipPlus5 + separator;
            ret += FArea + separator;
            ret += FAreaType + separator;

            ret += FGeometrySRID + separator;
            if (String.Compare(separator, ",", true) == 0)
            {
                ret += FGeometry.Replace(separator, ";") + separator;
            }
            else
            {
                ret += FGeometry + separator;
            }

            ret += FSource + separator;
            ret += FVintage + separator;
            ret += FPrimaryIdField + separator;
            ret += FPrimaryIdValue + separator;
            ret += FSecondaryIdField + separator;
            ret += FSecondaryIdValue;

            return ret;
        }

        // added:    CensusYear
        // replaced: Census2000 fields with Census fields (removed the 2000)

        public string AsStringVerbose_V02_96(string separator, double version)
        {
            string ret = "";
            ret += TransactionId + separator;
            ret += Version + separator;
            ret += QueryStatusCodeValue + separator;
            ret += Latitude + separator;
            ret += Longitude + separator;
            ret += MatchScore + separator;
            ret += MatchType + separator;
            ret += FeatureMatchingGeographyType + separator;
            ret += InterpolationType + separator;
            ret += InterpolationSubType + separator;
            ret += MatchedLocationType + separator;
            ret += FeatureMatchingResultType + separator;
            ret += FeatureMatchingResultCount + separator;
            ret += FeatureMatchingResultTypeNotes + separator;
            ret += FeatureMatchingResultTypeTieBreakingNotes + separator;
            ret += TieHandlingStrategyType + separator;
            ret += FeatureMatchingSelectionMethod + separator;
            ret += FeatureMatchingSelectionMethodNotes + separator;
            ret += TimeTaken + separator;

            ret += CensusYear + separator;
            ret += CensusBlock + separator;
            ret += CensusBlockGroup + separator;
            ret += CensusTract + separator;
            ret += CensusCountyFips + separator;
            ret += CensusCbsaFips + separator;
            ret += CensusCbsaMicro + separator;
            ret += CensusMcdFips + separator;
            ret += CensusMetDivFips + separator;
            ret += CensusMsaFips + separator;
            ret += CensusPlaceFips + separator;
            ret += CensusStateFips + separator;

            ret += MNumber + separator;
            ret += MNumberFractional + separator;
            ret += MPreDirectional + separator;
            ret += MPreQualifier + separator;
            ret += MPreType + separator;
            ret += MPreArticle + separator;
            ret += MName + separator;
            ret += MPostArticle + separator;
            ret += MPostQualifier + separator;
            ret += MSuffix + separator;
            ret += MPostDirectional + separator;
            ret += MSuiteType + separator;
            ret += MSuiteNumber + separator;
            ret += MPostOfficeBoxType + separator;
            ret += MPostOfficeBoxNumber + separator;
            ret += MCity + separator;
            ret += MConsolidatedCity + separator;
            ret += MMinorCivilDivision + separator;
            ret += MCountySubRegion + separator;
            ret += MCounty + separator;
            ret += MState + separator;
            ret += MZip + separator;
            ret += MZipPlus1 + separator;
            ret += MZipPlus2 + separator;
            ret += MZipPlus3 + separator;
            ret += MZipPlus4 + separator;
            ret += MZipPlus5 + separator;

            ret += PNumber + separator;
            ret += PNumberFractional + separator;
            ret += PPreDirectional + separator;
            ret += PPreQualifier + separator;
            ret += PPreType + separator;
            ret += PPreArticle + separator;
            ret += PName + separator;
            ret += PPostArticle + separator;
            ret += PPostQualifier + separator;
            ret += PSuffix + separator;
            ret += PPostDirectional + separator;
            ret += PSuiteType + separator;
            ret += PSuiteNumber + separator;
            ret += PPostOfficeBoxType + separator;
            ret += PPostOfficeBoxNumber + separator;
            ret += PCity + separator;
            ret += PConsolidatedCity + separator;
            ret += PMinorCivilDivision + separator;
            ret += PCountySubRegion + separator;
            ret += PCounty + separator;
            ret += PState + separator;
            ret += PZip + separator;
            ret += PZipPlus1 + separator;
            ret += PZipPlus2 + separator;
            ret += PZipPlus3 + separator;
            ret += PZipPlus4 + separator;
            ret += PZipPlus5 + separator;

            ret += FNumber + separator;
            ret += FNumberFractional + separator;
            ret += FPreDirectional + separator;
            ret += FPreQualifier + separator;
            ret += FPreType + separator;
            ret += FPreArticle + separator;
            ret += FName + separator;
            ret += FPostArticle + separator;
            ret += FPostQualifier + separator;
            ret += FSuffix + separator;
            ret += FPostDirectional + separator;
            ret += FSuiteType + separator;
            ret += FSuiteNumber + separator;
            ret += FPostOfficeBoxType + separator;
            ret += FPostOfficeBoxNumber + separator;
            ret += FCity + separator;
            ret += FConsolidatedCity + separator;
            ret += FMinorCivilDivision + separator;
            ret += FCountySubRegion + separator;
            ret += FCounty + separator;
            ret += FState + separator;
            ret += FZip + separator;
            ret += FZipPlus1 + separator;
            ret += FZipPlus2 + separator;
            ret += FZipPlus3 + separator;
            ret += FZipPlus4 + separator;
            ret += FZipPlus5 + separator;
            ret += FArea + separator;
            ret += FAreaType + separator;

            ret += FGeometrySRID + separator;
            if (String.Compare(separator, ",", true) == 0)
            {
                ret += FGeometry.Replace(separator, ";") + separator;
            }
            else
            {
                ret += FGeometry + separator;
            }

            ret += FSource + separator;
            ret += FVintage + separator;
            ret += FPrimaryIdField + separator;
            ret += FPrimaryIdValue + separator;
            ret += FSecondaryIdField + separator;
            ret += FSecondaryIdValue;

            return ret;
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
