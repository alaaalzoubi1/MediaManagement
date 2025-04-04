import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

const oAuthConfig = {
  issuer: 'https://localhost:44323/',
  redirectUri: baseUrl,
  clientId: 'MediaManagement_App',
  responseType: 'code',
  scope: 'offline_access MediaManagement',
  requireHttps: true,
};

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'MediaManagement',
  },
  oAuthConfig,
  apis: {
    default: {
      url: 'https://localhost:44323',
      rootNamespace: 'MediaManagement',
    },
    AbpAccountPublic: {
      url: oAuthConfig.issuer,
      rootNamespace: 'AbpAccountPublic',
    },
  },
  remoteEnv: {
    url: '/getEnvConfig',
    mergeStrategy: 'deepmerge'
  }
} as Environment;
