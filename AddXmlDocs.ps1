
function Get-MethodSummary {
    param([string]$name)
    $map = @{
        "ADMIN_QUOTATION_CLIENT_IU" = "Insert or update a quotation client record."
        "ADMIN_SALESENQUIRY_LIST_XL" = "Export the sales enquiry search list to an Excel file."
        "ADMIN_SALESENQUIRY_SEARCHLIST" = "Search and retrieve the sales enquiry list."
        "ADMIN_SALESENQUIRY_POPULATE" = "Populate the sales enquiry form with existing record data."
        "Admin_SalesEnquiry_IU" = "Insert or update a sales enquiry record."
        "ADMIN_SALESENQUIRY_PAGELOAD" = "Load dropdown and reference data for the sales enquiry page."
        "GetAdmingSalesEnquiryPageload" = "Load dropdown and reference data for the sales enquiry page (POST variant)."
        "ADMIN_QUOTATION_RESET" = "Reset temporary quotation data for the given VGUID session."
        "ADMIN_QUOTATION_TMP_DEL" = "Delete a temporary quotation detail row."
        "ADMIN_QUOTATION_PAGELOAD" = "Load dropdown reference data for the quotation page."
        "ADMIN_QUOTATION_SEARCHLIST" = "Search and retrieve the quotation list."
        "ADMIN_QUOTATION_POPULATE" = "Populate the quotation form with existing record data."
        "ADMIN_QUOTATION_CHILD_IU" = "Insert or update a temporary quotation charge detail row."
        "ADMIN_QUOTATION_MST_INSERT" = "Insert a new quotation master record."
        "ADMIN_QUOTATION_MST_UPDATE" = "Update an existing quotation master record."
        "Fill_Usercity" = "Retrieve the list of user cities for dropdown population."
        "Fill_Location" = "Retrieve the list of user locations for dropdown population."
        "Fill_UserPopulate" = "Retrieve the list of all users for dropdown population."
        "Profile_details_populate" = "Populate user profile details for the given user code."
        "Admin_Profile_IU" = "Insert or update a user profile record."
        "UploadFiles" = "Upload a file to the server and save it."
        "FillCity" = "Retrieve city list for the given user."
        "FillCompanyAll" = "Retrieve all companies for the given city code."
        "FillCompanyAllEDIT" = "Retrieve all companies for edit mode dropdown."
        "Acc_AddFinanceYear" = "Add a new financial year record for the given company and city."
        "ADMIN_FINANCIALYEAR_Search" = "Search financial year records within the given date range."
        "Fill_Admin_FinancialYearDetails" = "Retrieve financial year details for the given year ID."
        "Company_Master_IU" = "Insert or update a company master record."
        "Company_Address_IU" = "Insert a new company branch address record."
        "Company_Address_UPDATE" = "Update an existing company branch address record."
        "Company_Address_delete" = "Delete a company branch address record."
        "Company_Address_deleteNew" = "Permanently delete a company branch address record."
        "Fill_Company_Details" = "Retrieve company master details for the given company code."
        "Company_MST_Search" = "Search and retrieve all company master records."
        "Fill_CompanyBranch_DetailsPageLoad" = "Load company branch details at page load."
        "Companypageload" = "Load company page data for the given maker/user."
        "Company_MST_Search1" = "Search company master records by company name."
        "ADMIN_Fill_ChequePrintAuthority" = "Retrieve cheque print authority list for the given company and city."
        "ADMIN_BP_Bank_Payment_Group_FILL" = "Retrieve bank payment group data for the given company."
        "Admin_BP_Bank_Payment_Group_Add" = "Add or update a bank payment group entry."
        "ACC_CLIENT_RATE_PAGELOAD" = "Load dropdown reference data for the client rate page."
        "ACC_CLIENT_RATE_CHILD_IU" = "Insert or update a temporary client rate charge detail row."
        "ACC_CLIENT_RATE_MST_IU" = "Insert or update a client rate master record."
        "ACC_CLIENT_RATE_SEARCHLIST" = "Search and retrieve the client rate list."
        "ACC_CLIENT_RATE_POPULATE" = "Populate the client rate form with existing record data."
        "MST_QUOT_RATE_PAGELOAD" = "Load dropdown reference data for the master quotation rate page."
        "MST_QUOTATION_RATE_IU" = "Insert or update a master quotation rate record."
        "MST_QUOTATION_RATE_DELETE" = "Delete a master quotation rate record by ID."
        "MST_QUOTATION_RATE_GETDATAFORCLIENT" = "Retrieve master quotation rate data to populate client origin rates."
        "GetBranch" = "Retrieve branch/city list for the given company."
        "GetCompany" = "Retrieve company list for the given city and company context."
        "GetMenuList" = "Retrieve the application menu list from the JSON configuration file."
        "getVerifyRight" = "Verify user access rights for a given form and company."
        "getCompanyName" = "Retrieve company name and logo image details for the given company code."
        "getCityList" = "Retrieve the full list of cities for dropdown population."
        "getConsigneeList" = "Retrieve the full list of consignees for dropdown population."
        "GetFinancialYear" = "Retrieve the financial year list for the given company and city."
        "GetFillcity" = "Retrieve the common city fill list for dropdown population."
        "FillCompany" = "Retrieve all companies for the master company dropdown."
        "MASTER_QUOTATION_PRINT" = "Retrieve quotation data for print view by quotation code."
        "MST_GENERAL_ACCOUNT_TDS_TMP_IU_NG" = "Insert or update a temporary TDS detail row for a general account."
        "MST_GENERAL_ACCOUNT_RESET" = "Reset temporary general account data for the given VGUID session."
        "MST_GENERAL_ACCOUNT_POPULATE_NG" = "Populate the general account form with existing record data (NG version)."
        "GenActMstpageload" = "Load dropdown reference data for the general account master page."
        "MST_GENERAL_ACCOUNT_IU_NG" = "Insert or update a general account master record (NG version)."
        "GET_MST_ACCOUNTS_ITEMCODE" = "Retrieve the accounts item code list for dropdown population."
        "populatecountry" = "Retrieve the country list for dropdown population."
        "populateCity" = "Populate city details for the given city code."
        "cityIU" = "Insert or update a city master record."
        "searchlist" = "Search city records by name."
        "Fill_Exp_Details" = "Retrieve exporter/client details for the given exporter code."
        "Fill_BranchCity" = "Retrieve the branch city list for dropdown population."
        "exporter_child_IU" = "Insert or update an exporter invoice address child record."
        "exporter_child_delete" = "Delete a temporary exporter address child record."
        "Exporter_Main_IU" = "Insert or update an exporter/client master record."
        "RemoveUploadFiles" = "Remove an uploaded document file from the server."
        "masterpageload" = "Load dropdown reference data for the master page."
        "con_documentList_load" = "Retrieve the consignee document type list."
        "Consignee_IU" = "Insert or update a consignee master record."
        "consignee_populate" = "Populate the consignee form with existing record data."
        "Fill_Consg_Details_AddAs_Expoter" = "Fill consignee details to add as an exporter record."
        "Master_Search_common" = "Common master search across exporters, consignees, suppliers, and agents."
        "Master_REQLIST_DELETE" = "Delete an exporter request list entry."
        "SUPPLIER_CHILD_IU" = "Insert or update a supplier address child record."
        "SUPPLIER_CHILD_TDS_IU" = "Insert or update a supplier TDS detail child record."
        "SUPPLIER_MASTER_IU" = "Insert or update a supplier master record."
        "Master_supplier_Populate" = "Populate the supplier form with existing record data."
        "Supplierpageload" = "Load dropdown reference data for the supplier master page."
        "Master_REQLIST_DELETE_consignee" = "Delete a consignee request list entry."
        "Master_REQLIST_DELETE_Supplier" = "Delete a supplier request list entry."
        "Master_REQLIST_DELETE_Agent" = "Delete an agent request list entry."
        "Master_REQLIST_DELETE_Liner" = "Delete a liner request list entry."
        "AgentFill" = "Retrieve the liner list for vessel agent dropdown population."
        "Master_VesselAgent_Populate" = "Populate the vessel agent form with existing record data."
        "Vessel_Agent_MASTER_IU" = "Insert or update a vessel agent master record."
        "Shiping_liner_IU" = "Insert or update a shipping liner master record."
        "Master_Liner_Populate" = "Populate the liner form with existing record data."
        "Consignee_bank_IU" = "Insert or update a consignee bank master record."
        "Master_bankdet_Populate" = "Populate the consignee bank form with existing record data."
        "MST_GENERAL_ACCOUNT_FILL" = "Retrieve the full list of general accounts for dropdown population."
        "MST_GENERAL_ACCOUNT_IU" = "Insert or update a general account master record."
        "MST_GENERAL_ACCOUNT_SEARCH" = "Search general account records with multiple filter criteria."
        "MST_GENERAL_ACCOUNT_POPULATE" = "Populate the general account form with existing record data."
        "MST__ACCOUNTS_ITEMCODE_FILL_DROPDOWN" = "Retrieve item codes for dropdown population."
        "MST_ACCOUNTS_ITEMCODE_FILL_DROPDOWN_CITY" = "Retrieve item codes for the given company for dropdown population."
        "MST_ACCOUNTS_ITEMCODE_FILL_GRID" = "Search and retrieve item code records for the grid display."
        "MST_ACCOUNTS_ITEMCODE_IU" = "Insert a new accounts item code record."
        "MST_ACCOUNTS_ITEMCODE_UPDATE" = "Update an existing accounts item code record."
        "ACC_CHARGEMASTER_ACCOUNT_FILL" = "Retrieve the charge master account list for dropdown population."
        "ACC_CHARGE_MASTER_IU" = "Insert or update a charge master record."
        "ACC_CHARGE_MASTER_POPULATE" = "Populate the charge master form with existing record data."
        "ACC_CHARGE_MASTER_SEARCH" = "Search charge master records with filter criteria."
        "SUPPLIER_CHILD_TDS_IU_NG" = "Insert or update a supplier TDS detail record (NG version)."
        "supplier_TempAddress_delete" = "Delete a temporary supplier address child record."
        "supplier_Address_delete" = "Delete a confirmed supplier address record."
    }
    if ($map.ContainsKey($name)) { return $map[$name] }
    # Auto-generate from name
    $words = $name -replace '([A-Z])', ' $1' -replace '_', ' ' -replace '\s+', ' '
    return "$($words.Trim()) operation."
}

function Get-ParamDescription {
    param([string]$pname)
    $lower = $pname.ToLower()
    switch -Regex ($lower) {
        '^(cmpcode|cmp_code)$'   { return "Company code identifier." }
        '^citycode$'             { return "City/branch code." }
        '^citycode1$'            { return "Secondary city/branch code." }
        '^cmpid$'                { return "Primary key of the company." }
        '^makerid$'              { return "User code of the record maker." }
        '^makerip$'              { return "IP address of the record maker." }
        '^(vguid|guid)$'         { return "Session GUID for temporary record management." }
        '^(fromdate|startdate|startdt|frmdt|fromdt|frdt)$' { return "Start date for the date range filter." }
        '^(todate|enddate|enddt|todt)$' { return "End date for the date range filter." }
        '^searchval$'            { return "Search field/column identifier." }
        '^(searchtxt|searchtext)$' { return "Search text value." }
        '^(pkid|id)$'            { return "Primary key ID of the record." }
        '^(mode|requestmode)$'   { return "Operation mode or filter type." }
        '^client$'               { return "Client/exporter code." }
        '^exptno$'               { return "Export job number." }
        '^jobno$'                { return "Job number." }
        '^invno$'                { return "Invoice number." }
        default {
            $desc = $pname -replace '([A-Z])', ' $1' -replace '_', ' ' -replace '\s+', ' '
            return "$($desc.Trim()) parameter."
        }
    }
}

function Get-ParamDocs {
    param([string]$paramStr, [string]$indent)
    $docs = [System.Collections.Generic.List[string]]::new()
    if ([string]::IsNullOrWhiteSpace($paramStr)) { return $docs }
    $paramStr = $paramStr -replace '\).*$', ''
    # split on commas that are not inside angle brackets
    $params = $paramStr -split ',\s*'
    foreach ($p in $params) {
        $p = $p.Trim()
        if ($p -match '\[FromBody\]\s*\S+\s+(\w+)') {
            $docs.Add("$indent/// <param name=`"$($Matches[1])`">Request body model containing the record fields.</param>")
        } elseif ($p -match '(?:\[[^\]]*\]\s*)?(?:string|int|bool|decimal|String|long|double)\s+(\w+)') {
            $pname = $Matches[1]
            $pdesc = Get-ParamDescription $pname
            $docs.Add("$indent/// <param name=`"$pname`">$pdesc</param>")
        }
    }
    return $docs
}

function Get-ReturnDoc {
    param([string]$returnType, [string]$indent)
    if ($returnType -eq "HttpResponseMessage") {
        return "$indent/// <returns>File download (Excel or similar) containing the report data.</returns>"
    }
    return "$indent/// <returns>DataSet with the requested data serialized as JSON.</returns>"
}

function Add-XmlDocComments {
    param([string]$filePath)

    $lines = Get-Content $filePath -Encoding UTF8
    $newLines = [System.Collections.Generic.List[string]]::new()
    $changes = 0

    for ($i = 0; $i -lt $lines.Count; $i++) {
        $line = $lines[$i]

        if ($line -match '^\s+\[Http(Get|Post)\]' -and $line -notmatch '^\s*//') {
            $prevLine = if ($newLines.Count -gt 0) { $newLines[$newLines.Count - 1] } else { "" }

            if ($prevLine -notmatch '///\s*<(summary|returns|param)') {
                # Find method signature (skip [Route] lines)
                $methodIdx = $i + 1
                while ($methodIdx -lt $lines.Count -and $lines[$methodIdx] -match '^\s+\[(Route|HttpGet|HttpPost)') {
                    $methodIdx++
                }
                $methodLine = $lines[$methodIdx]

                $returnType = "IHttpActionResult"
                $methodName = ""
                $paramStr = ""

                if ($methodLine -match 'public\s+([\w<>]+)\s+(\w+)\((.*?)(?:\)|$)') {
                    $returnType = $Matches[1]
                    $methodName = $Matches[2]
                    $paramStr = $Matches[3]
                }

                # Get indentation
                $indent = "        "
                if ($line -match '^(\s+)') { $indent = $Matches[1] }

                $summary = Get-MethodSummary $methodName
                $paramDocs = Get-ParamDocs $paramStr $indent
                $returnDoc = Get-ReturnDoc $returnType $indent

                $newLines.Add("$indent/// <summary>$summary</summary>")
                foreach ($pd in $paramDocs) { $newLines.Add($pd) }
                $newLines.Add($returnDoc)
                $changes++
            }
        }

        $newLines.Add($line)
    }

    Write-Host "  $([System.IO.Path]::GetFileName($filePath)): added $changes XML doc comment blocks"
    [System.IO.File]::WriteAllLines($filePath, $newLines, [System.Text.Encoding]::UTF8)
}

# Process all controller files
$files = @(
    'C:\development-manilal\ManilalV5_WebApi\Manilal_V5NG\Controllers\Admin\AdminController.cs'
    'C:\development-manilal\ManilalV5_WebApi\Manilal_V5NG\Controllers\Admin\CompanyController.cs'
    'C:\development-manilal\ManilalV5_WebApi\Manilal_V5NG\Controllers\BranchBLL\BranchController.cs'
    'C:\development-manilal\ManilalV5_WebApi\Manilal_V5NG\Controllers\CommonBLL\CommonController.cs'
    'C:\development-manilal\ManilalV5_WebApi\Manilal_V5NG\Controllers\MasterBLL\MasterController.cs'
    'C:\development-manilal\ManilalV5_WebApi\Manilal_V5NG\Controllers\AccountsBLL\AccountsController.cs'
    'C:\development-manilal\ManilalV5_WebApi\Manilal_V5NG\Controllers\AccountsFraBLL\AccountsFraController.cs'
    'C:\development-manilal\ManilalV5_WebApi\Manilal_V5NG\Controllers\ExportBLL\ExportController.cs'
    'C:\development-manilal\ManilalV5_WebApi\Manilal_V5NG\Controllers\ImportBLL\ImportController.cs'
    'C:\development-manilal\ManilalV5_WebApi\Manilal_V5NG\Controllers\ImportfraBLL\ImportfraController.cs'
    'C:\development-manilal\ManilalV5_WebApi\Manilal_V5NG\Controllers\EdiBLL\EdiController.cs'
)

foreach ($f in $files) {
    if (Test-Path $f) {
        Add-XmlDocComments $f
    } else {
        Write-Host "  NOT FOUND: $f"
    }
}

Write-Host "Done."
