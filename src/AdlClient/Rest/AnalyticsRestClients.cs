﻿using AdlClient.Rest;
using MSADLA = Microsoft.Azure.Management.DataLake.Analytics;
namespace AdlClient
{
    public class AnalyticsRestClients
    {
        public readonly AnalyticsCatalogRestWrapper _CatalogRest;
        public readonly AnalyticsAccountManagmentRestWrapper _AdlaAccountMgmtRest;
        public readonly Microsoft.Azure.Graph.RBAC.GraphRbacManagementClient AADclient;

        public readonly MSADLA.DataLakeAnalyticsJobManagementClient Jobs;

        public AnalyticsRestClients(Authentication authSession, AdlClient.Models.AnalyticsAccountRef account)
        {
            this._CatalogRest = new AnalyticsCatalogRestWrapper(authSession.ADLCreds);
            this._AdlaAccountMgmtRest = new AnalyticsAccountManagmentRestWrapper(account.SubscriptionId, authSession.ARMCreds);
            this.AADclient = new Microsoft.Azure.Graph.RBAC.GraphRbacManagementClient(authSession.AADCreds);
            this.AADclient.TenantID = authSession.Tenant;

            this.Jobs = new MSADLA.DataLakeAnalyticsJobManagementClient(authSession.ADLCreds);
        }
    }
}