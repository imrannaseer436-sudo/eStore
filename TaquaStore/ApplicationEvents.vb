Namespace My

    ' The following events are available for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication

        Public AppVersion As Short = 1312
        Private VersionPath As String = ""

        Private Sub MyApplication_Startup(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup

            programUpdater(e)
            'My.Application.MainForm = frmPurchaseReport
            'writeConfigFile()

        End Sub

        Private Sub LoadVersionPath()

            VersionPath = ""

            If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\StoreSettings.xml") = True Then

                Dim xRdr As New Xml.XmlTextReader(My.Application.Info.DirectoryPath & "\StoreSettings.xml")
                While xRdr.Read
                    If xRdr.Name = "VersionPath" Then
                        VersionPath = xRdr.ReadElementString("VersionPath")
                    End If
                End While
                xRdr.Close()

            End If

        End Sub

        Private Sub programUpdater(e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs)

            LoadVersionPath()
            If VersionPath = "" Then
                MsgBox("Version path not configured..!", MsgBoxStyle.Information)
            Else

                Try

                    Dim WC As New System.Net.WebClient

                    Dim NewVersion As String = WC.DownloadString(VersionPath)
                    If Val(NewVersion) > AppVersion Then
                        If MsgBox("Update available, Do you want to update..!", MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            Shell(Application.Info.DirectoryPath & "\" & "UniversalUpdater.exe", AppWinStyle.NormalFocus)
                            e.Cancel = True
                        End If
                    End If

                Catch ex As System.Net.WebException

                Catch ex1 As Exception

                End Try

            End If

        End Sub

        Private Sub writeConfigFile()

            Dim appPath = My.Application.Info.DirectoryPath & "\" & My.Application.Info.ProductName & ".exe.config"
            Dim xmllDoc As New System.Xml.XmlDocument
            Dim xmlTag As String = <![CDATA[<?xml version="1.0"?>
<configuration>
    <system.diagnostics>
        <sources>
            <!-- This section defines the logging configuration for My.Application.Log -->
            <source name="DefaultSource" switchName="DefaultSwitch">
                <listeners>
                    <add name="FileLog"/>
                    <!-- Uncomment the below section to write to the Application Event Log -->
                    <!--<add name="EventLog"/>-->
                </listeners>
            </source>
        </sources>
        <switches>
            <add name="DefaultSwitch" value="Information"/>
        </switches>
        <sharedListeners>
            <add name="FileLog" type="Microsoft.VisualBasic.Logging.FileLogTraceListener, Microsoft.VisualBasic, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a, processorArchitecture=MSIL" initializeData="FileLogWriter"/>
            <!-- Uncomment the below section and replace APPLICATION_NAME with the name of your application to write to the Application Event Log -->
            <!--<add name="EventLog" type="System.Diagnostics.EventLogTraceListener" initializeData="APPLICATION_NAME"/> -->
        </sharedListeners>
    </system.diagnostics>
  <startup useLegacyV2RuntimeActivationPolicy="true">
    <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.0"/>
  </startup>
  <runtime>
    <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">
      <dependentAssembly>
        <assemblyIdentity name="System.Web.Services" publicKeyToken="B03F5F7F11D50A3A" culture="neutral"/>
        <bindingRedirect oldVersion="0.0.0.0-4.0.0.0" newVersion="4.0.0.0"/>
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name="DocumentFormat.OpenXml" publicKeyToken="8fb06cb64d019a17" culture="neutral"/>
        <bindingRedirect oldVersion="0.0.0.0-2.8.1.0" newVersion="2.8.1.0"/>
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name="CrystalDecisions.CrystalReports.Engine" publicKeyToken="692fbea5521e1304" culture="neutral"/>
        <bindingRedirect oldVersion="13.0.2000.0" newVersion="13.0.3500.0"/>
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name="CrystalDecisions.ReportSource" publicKeyToken="692fbea5521e1304" culture="neutral"/>
        <bindingRedirect oldVersion="13.0.2000.0" newVersion="13.0.3500.0"/>
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name="CrystalDecisions.Shared" publicKeyToken="692fbea5521e1304" culture="neutral"/>
        <bindingRedirect oldVersion="13.0.2000.0" newVersion="13.0.3500.0"/>
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name="CrystalDecisions.Web" publicKeyToken="692fbea5521e1304" culture="neutral"/>
        <bindingRedirect oldVersion="13.0.2000.0" newVersion="13.0.3500.0"/>
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name="CrystalDecisions.Windows.Forms" publicKeyToken="692fbea5521e1304" culture="neutral"/>
        <bindingRedirect oldVersion="13.0.2000.0" newVersion="13.0.3500.0"/>
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name="CrystalDecisions.ReportAppServer.ClientDoc" publicKeyToken="692fbea5521e1304" culture="neutral"/>
        <bindingRedirect oldVersion="13.0.2000.0" newVersion="13.0.3500.0"/>
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name="CrystalDecisions.ReportAppServer.CommonControls" publicKeyToken="692fbea5521e1304" culture="neutral"/>
        <bindingRedirect oldVersion="13.0.2000.0" newVersion="13.0.3500.0"/>
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name="CrystalDecisions.ReportAppServer.CommonObjectModel" publicKeyToken="692fbea5521e1304" culture="neutral"/>
        <bindingRedirect oldVersion="13.0.2000.0" newVersion="13.0.3500.0"/>
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name="CrystalDecisions.ReportAppServer.Controllers" publicKeyToken="692fbea5521e1304" culture="neutral"/>
        <bindingRedirect oldVersion="13.0.2000.0" newVersion="13.0.3500.0"/>
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name="CrystalDecisions.ReportAppServer.CubeDefModel" publicKeyToken="692fbea5521e1304" culture="neutral"/>
        <bindingRedirect oldVersion="13.0.2000.0" newVersion="13.0.3500.0"/>
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name="CrystalDecisions.ReportAppServer.DataDefModel" publicKeyToken="692fbea5521e1304" culture="neutral"/>
        <bindingRedirect oldVersion="13.0.2000.0" newVersion="13.0.3500.0"/>
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name="CrystalDecisions.ReportAppServer.DataSetConversion" publicKeyToken="692fbea5521e1304" culture="neutral"/>
        <bindingRedirect oldVersion="13.0.2000.0" newVersion="13.0.3500.0"/>
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name="CrystalDecisions.ReportAppServer.ObjectFactory" publicKeyToken="692fbea5521e1304" culture="neutral"/>
        <bindingRedirect oldVersion="13.0.2000.0" newVersion="13.0.3500.0"/>
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name="CrystalDecisions.ReportAppServer.Prompting" publicKeyToken="692fbea5521e1304" culture="neutral"/>
        <bindingRedirect oldVersion="13.0.2000.0" newVersion="13.0.3500.0"/>
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name="CrystalDecisions.ReportAppServer.ReportDefModel" publicKeyToken="692fbea5521e1304" culture="neutral"/>
        <bindingRedirect oldVersion="13.0.2000.0" newVersion="13.0.3500.0"/>
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name="CrystalDecisions.ReportAppServer.XmlSerialize" publicKeyToken="692fbea5521e1304" culture="neutral"/>
        <bindingRedirect oldVersion="13.0.2000.0" newVersion="13.0.3500.0"/>
      </dependentAssembly>
    </assemblyBinding>
  </runtime>
</configuration>]]>.Value()

            xmllDoc.LoadXml(xmlTag)
            xmllDoc.Save(appPath)

        End Sub

    End Class

End Namespace

