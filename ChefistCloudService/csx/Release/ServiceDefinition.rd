<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="ChefistCloudService" generation="1" functional="0" release="0" Id="7e0a5095-8027-484a-b88c-39ceb7004b53" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="ChefistCloudServiceGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="WebRole1:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/ChefistCloudService/ChefistCloudServiceGroup/LB:WebRole1:Endpoint1" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="WebRole1:APPINSIGHTS_INSTRUMENTATIONKEY" defaultValue="">
          <maps>
            <mapMoniker name="/ChefistCloudService/ChefistCloudServiceGroup/MapWebRole1:APPINSIGHTS_INSTRUMENTATIONKEY" />
          </maps>
        </aCS>
        <aCS name="WebRole1:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/ChefistCloudService/ChefistCloudServiceGroup/MapWebRole1:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="WebRole1Instances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/ChefistCloudService/ChefistCloudServiceGroup/MapWebRole1Instances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:WebRole1:Endpoint1">
          <toPorts>
            <inPortMoniker name="/ChefistCloudService/ChefistCloudServiceGroup/WebRole1/Endpoint1" />
          </toPorts>
        </lBChannel>
      </channels>
      <maps>
        <map name="MapWebRole1:APPINSIGHTS_INSTRUMENTATIONKEY" kind="Identity">
          <setting>
            <aCSMoniker name="/ChefistCloudService/ChefistCloudServiceGroup/WebRole1/APPINSIGHTS_INSTRUMENTATIONKEY" />
          </setting>
        </map>
        <map name="MapWebRole1:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/ChefistCloudService/ChefistCloudServiceGroup/WebRole1/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapWebRole1Instances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/ChefistCloudService/ChefistCloudServiceGroup/WebRole1Instances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="WebRole1" generation="1" functional="0" release="0" software="C:\Users\dbkwo\Documents\GitHub\Cloud-Project\ChefistCloudService\csx\Release\roles\WebRole1" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="-1" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="80" />
            </componentports>
            <settings>
              <aCS name="APPINSIGHTS_INSTRUMENTATIONKEY" defaultValue="" />
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;WebRole1&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;WebRole1&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/ChefistCloudService/ChefistCloudServiceGroup/WebRole1Instances" />
            <sCSPolicyUpdateDomainMoniker name="/ChefistCloudService/ChefistCloudServiceGroup/WebRole1UpgradeDomains" />
            <sCSPolicyFaultDomainMoniker name="/ChefistCloudService/ChefistCloudServiceGroup/WebRole1FaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyUpdateDomain name="WebRole1UpgradeDomains" defaultPolicy="[5,5,5]" />
        <sCSPolicyFaultDomain name="WebRole1FaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="WebRole1Instances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="ec44503e-9923-41f9-a987-f01d1206fd28" ref="Microsoft.RedDog.Contract\ServiceContract\ChefistCloudServiceContract@ServiceDefinition">
      <interfacereferences>
        <interfaceReference Id="bea09da8-9816-47e1-82ae-aad3f504db0c" ref="Microsoft.RedDog.Contract\Interface\WebRole1:Endpoint1@ServiceDefinition">
          <inPort>
            <inPortMoniker name="/ChefistCloudService/ChefistCloudServiceGroup/WebRole1:Endpoint1" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>