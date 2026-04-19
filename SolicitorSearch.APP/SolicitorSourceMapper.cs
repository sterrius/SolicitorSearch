using SolicitorSearch.BLL.SolicitorSource;
using SolicitorSearch.DAL.Entities;

namespace SolicitorSearch.APP;

public static class SolicitorSourceMapper
{
    private const string SOLICITORSDOTCOM_NAME = "solicitorsdotcom";

    public static SolicitorSourceBaseModel MapToSolicitorSourceModel(this SolicitorSourceEntity solicitorSourceEntity)
    {
        switch (solicitorSourceEntity.SolicitorSourceName?.ToLower())
        {
            case SOLICITORSDOTCOM_NAME:
                {
                    return new SolicitorsDotComSolicitorSourceModel(solicitorSourceEntity.SolicitorSourceId, solicitorSourceEntity.SolicitorSourceName, solicitorSourceEntity.BaseUrl, solicitorSourceEntity.QueryStringTemplate, solicitorSourceEntity.HostHeader);
                }
            default:
                {
                    return new SolicitorSourceBaseModel(solicitorSourceEntity.SolicitorSourceId, solicitorSourceEntity.SolicitorSourceName, solicitorSourceEntity.BaseUrl, solicitorSourceEntity.QueryStringTemplate, solicitorSourceEntity.HostHeader);
                }
        }
    }
}
