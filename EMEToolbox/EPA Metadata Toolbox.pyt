import arcpy


class Toolbox(object):
    def __init__(self):
        """Define the toolbox (the name of the toolbox is the name of the
        .pyt file)."""
        self.label = "Toolbox"
        self.alias = ""

        # List of tool classes associated with this toolbox
        self.tools = [upgradeTool,cleanupTool]


class upgradeTool(object):
    def __init__(self):
        """Define the tool (tool name is the name of the class)."""
        self.label = "EPA Upgrade FGDC to ArcGIS"
        self.description = "This tool creates a copy of the existing FGDC CSDGM metadata, performs the standard upgrade to ArcGIS Metadata, then adds several extra cleanup steps including copying legacy UUIDs to the ISO-Compliant element and cleaning up all legacy elements. This tool is not recommended for records that have already been upgraded to ArcGIS Metadata."
        self.canRunInBackground = False

    def getParameterInfo(self):
        """Define parameter definitions"""
            # Second parameter
        param0 = arcpy.Parameter(
            displayName="Source Metadata",
            name="sourcemetadata",
            datatype="DEType",
            parameterType="Required",
            direction="Input")

        # Third parameter
        param1 = arcpy.Parameter(
            displayName="Output Metadata",
            name="out_metadata",
            datatype="DEFile",
            parameterType="Required",
            direction="Output")
            
        params = [param0, param1]
        return params

    def isLicensed(self):
        """Set whether tool is licensed to execute."""
        return True

    def updateParameters(self, parameters):
        """Modify the values and properties of parameters before internal
        validation is performed.  This method is called whenever a parameter
        has been changed."""
        return

    def updateMessages(self, parameters):
        """Modify the messages created by internal validation for each tool
        parameter.  This method is called after internal validation."""
        return

    def execute(self, parameters, messages):
        try:
            """The source code of the tool."""
            Source_Metadata = parameters[0].valueAsText
            Output_Metadata = parameters[1].valueAsText
            
            # Local variables:
            exact_copy_of_xslt = "exactCopyOf.xslt"
            Copy_to_be_upgraded = "%scratchworkspace%\\metadatatoupgrade.xml"
            EPAUpgradeCleanup_xslt = "EPAUpgradeCleanup.xslt"

            messages.addMessage("Making a temporary copy of the existing metadata to upgrade...")
            # Process: Copy Metadata for Upgrade
            arcpy.XSLTransform_conversion(Source_Metadata, exact_copy_of_xslt, Copy_to_be_upgraded, "")

            messages.addMessage("Upgrading the metadata...")
            # Process: Upgrade Metadata
            Upgraded_Metadata = arcpy.UpgradeMetadata_conversion(Copy_to_be_upgraded, "FGDC_TO_ARCGIS")

            messages.addMessage("Preserving the UUID and cleaning up legacy elements...")
            # Process: EPA Cleanup
            arcpy.XSLTransform_conversion(Upgraded_Metadata, EPAUpgradeCleanup_xslt, Output_Metadata, "")
            
            messages.addMessage("Process complete - please review the output carefully before importing or harvesting.")
        except:
            # Cycle through Geoprocessing tool specific errors
            for msg in range(0, arcpy.GetMessageCount()):
                if arcpy.GetSeverity(msg) == 2:
                    arcpy.AddReturnMessage(msg)
        finally:
            # Regardless of errors, clean up intermediate products.
            arcpy.Delete_management(Copy_to_be_upgraded)
        return

class cleanupTool(object):
    def __init__(self):
        """Define the tool (tool name is the name of the class)."""
        self.label = "EPA Cleanup ArcGIS Record"
        self.description = "This tool performs several extra cleanup steps including copying legacy UUIDs to the ISO-Compliant element and cleaning up all legacy elements. This tool is recommended for records that have already been upgraded to ArcGIS Metadata."
        self.canRunInBackground = False

    def getParameterInfo(self):
        """Define parameter definitions"""
            # Second parameter
        param0 = arcpy.Parameter(
            displayName="Source Metadata",
            name="sourcemetadata",
            datatype="DEType",
            parameterType="Required",
            direction="Input")

        # Third parameter
        param1 = arcpy.Parameter(
            displayName="Output Metadata",
            name="out_metadata",
            datatype="DEFile",
            parameterType="Required",
            direction="Output")
            
        params = [param0, param1]
        return params

    def isLicensed(self):
        """Set whether tool is licensed to execute."""
        return True

    def updateParameters(self, parameters):
        """Modify the values and properties of parameters before internal
        validation is performed.  This method is called whenever a parameter
        has been changed."""
        return

    def updateMessages(self, parameters):
        """Modify the messages created by internal validation for each tool
        parameter.  This method is called after internal validation."""
        return

    def execute(self, parameters, messages):
        try:
            """The source code of the tool."""
            Source_Metadata = parameters[0].valueAsText
            Output_Metadata = parameters[1].valueAsText
            
            # Local variables:
            EPAUpgradeCleanup_xslt = "EPAUpgradeCleanup.xslt"

            messages.addMessage("Preserving the UUID and cleaning up legacy elements...")
            # Process: EPA Cleanup
            arcpy.XSLTransform_conversion(Source_Metadata, EPAUpgradeCleanup_xslt, Output_Metadata, "")
            
            messages.addMessage("Process complete - please review the output carefully before importing or harvesting.")
        except:
            # Cycle through Geoprocessing tool specific errors
            for msg in range(0, arcpy.GetMessageCount()):
                if arcpy.GetSeverity(msg) == 2:
                    arcpy.AddReturnMessage(msg)
        finally:
            # Regardless of errors, clean up intermediate products.
            pass
        return
        