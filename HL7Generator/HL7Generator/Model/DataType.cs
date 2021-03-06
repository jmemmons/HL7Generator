﻿using System.ComponentModel;

namespace HL7Generator.Base.Model
{
    public enum DataType
    {
        [Description("Address")] AD,
        [Description("Authorization Information")] AUI,
        [Description("Charge Code and Date")] CCD,
        [Description("Channel Calibration Parameters")] CCP,
        [Description("Channel Definition")] CD,
        [Description("Coded Element")] CE,
        [Description("Coded Element with Formatted Values")] CF,
        [Description("Coded with No Exceptions")] CNE,
        [Description("Composite ID Number and Name Simplified")] CNN,
        [Description("Composite Price")] CP,
        [Description("Composite Quantity with Units")] CQ,
        [Description("Channel Sensitivty")] CSU,
        [Description("Coded with Exceptions")] CWE,
        [Description("Extended Composite ID with Check Digit")] CX,
        [Description("Daily Deductible Information")] DDI,
        [Description("Date and Institution Name")] DIN,
        [Description("Discharge Location and Date")] DLD,
        [Description("Delta")] DLT,
        [Description("Date/Time range")] DR,
        [Description("Date")] DT,
        [Description("Date/Time")] DTM,
        [Description("Entity Identifier")] EI,
        [Description("Entity Identity Pair")] EIP,
        [Description("Formatted text")] FT,
        [Description("Hierachic Designator")] HD,
        [Description("Coded values for HL7 tables")] ID,
        [Description("Coded value for user-defined tables")] IS,
        [Description("Money and Code")] MOC,
        [Description("Message Type")] MSG,
        [Description("Name with Date and Location")] NDL,
        [Description("Numeric")] NM,
        [Description("Person Location")] PL,
        [Description("Parent Result Link")] PRL,
        [Description("Processing Type")] PT,
        [Description("Sequence ID")] SI,
        [Description("Structured Numeric")] SN,
        [Description("Specimen Source")] SPS,
        [Description("String")] ST,
        [Description("Time")] TM,
        [Description("Timing/Quantity")] TQ,
        [Description("Time stamp")] TS,
        [Description("Text data")] TX,
        [Description("Variable data type")] VARIES,
        [Description("Version Identifier")] VID,
        [Description("Extended Address")] XAD,
        [Description("Extended composite ID number and name")] XCN,
        [Description("Extended Composite Name and Identification Number for Organizations")] XON,
        [Description("Extended Person Name")] XPN,
        [Description("Extended Telecommunication Number")] XTN
    }
}
