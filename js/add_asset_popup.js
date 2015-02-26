function assetSearch() {
    window.open("assetSearch.aspx", "List", "toolbar=no,location=no,status=no,menubar=no,scrollbars=yes,resizable=no, width=600,height=500");
    return false;
}

function addDepartment() {
    window.open("addDepartment.aspx", "List", "toolbar=no,location=no,status=no,menubar=no,scrollbars=yes,resizable=no, width=600,height=500");
    return false;
}

function manageTemplates() {
    window.open("manageTemplates.aspx", "List", "toolbar=no,location=no,status=no,menubar=no,scrollbars=yes,resizable=no, width=600,height=500");
    return false;
}

function viewSheet() {
    window.open("img/Denise_Krenski_Laptop.PDF");
    window.close();
}

function downloadSheet() {
    window.confirm("Download Sign Sheet");
    return false;
}

function saveChanges() {
    window.confirm("Are you sure you want to save your changes?");
    return false;
}

function uploadSoS() {
    window.open("uploadSoS.aspx", "List", "toolbar=no,location=no,status=no,menubar=no,scrollbars=yes,resizable=no, width=600,height=500");
    return false;
}

function emailSheet() {
    window.confirm("Do you want to send Sign Sheet to recipient?");
    return false;
}

function assetSearchClose() {
    window.close()
     location.reload(true);
    
}

