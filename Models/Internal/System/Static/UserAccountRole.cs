namespace TaftaCRM.Models.Internal.System.Static;

public enum UserAccountRole
{
    [StringValue("Administrator")]
    Administrator,

    [StringValue("Sales Manager")]
    SalesManager,

    [StringValue("Sales Representative")]
    SalesRepresentative,

    [StringValue("Customer Support")]
    CSR,

    [StringValue("Marketing Manager")]
    MarketingManager,

    [StringValue("Data Analyst")]
    DataAnalyst,

    [StringValue("Pleb")]
    Pleb
}