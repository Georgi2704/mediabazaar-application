<?php session_start(); ?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <link href="main.css" type="text/css" rel="stylesheet">
    <link href="profileStyle.css" type="text/css" rel="stylesheet">
    <title>Media Bazaar - Hardware Store</title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>

</head>
<body background="mbImages/bglong2.jpg">
<header>
    <div class="menu">
        <a href="HomePage.php"><img src="mbImages/mediabazaar.png" alt="logo" class="logo">
            <nav>
                <ul>
                    <li><a href="Logout.php">Log Out</a></li>
                    <li><a href="HomePage.php">Home</a></li>
                    <li><a href="ContactManager.php">Contact manager</a></li>
                    <li><a href="Contracts.php">View my contracts</a></li>
                    <li><a href= "UserProfile.php">
                            Profile and Shifts - <?php echo "{$_SESSION['fname'] }  {$_SESSION['lname']}"?>
                        </a>
                </ul>
            </nav>
        </a>
    </div>
</header>

<div class="ctrctInfo">
    <h2>Contract history</h2>
    <div id="initial" style="background-color:#aaa;">
        <h2 style="color: #aaa">nothing</h2>
        <p>Initial contract</p>
    </div>
    <div class="rowC">
        <div class="columnC" id="contractDate" style="background-color:#aaa;">
            <h2>Date of Change</h2>
        </div>
        <div class="columnC" id="contractSalary" style="background-color:#bbb;">
            <h2>New Salary</h2>

        </div>
        <div class="columnC" id="contractDepartment" style="background-color:#ccc;">
            <h2>New Department</h2>

        </div>
        <div class="columnC" id="contractPosition" style="background-color:#ddd;">
            <h2>New Position</h2>

        </div>
    </div>
</div>
<footer class="footer">All rights reserved (c) 2020 George Manev</footer>
</body>

<?php
function debug_to_console($data) {
    $output = $data;
    if (is_array($output))
        $output = implode(',', $output);

    echo "<script>console.log('Debug Objects: " . $output . "' );</script>";
}


include "QueryContracts.php";
function getContractValues(){
    $dateTwoValues = GetDateOfChange();
    $salaryTwoValues = GetNewSalary();
    $departmentTwoValues = GetNewDepartment();
    $positionTwoValues = GetNewPosition();
    $dateArray = array();
    $salaryArray = array();
    $departmentArray = array();
    $positionArray = array();

    //Convert the associative array into indexed array
    for ($i = 0; $i < count($dateTwoValues); $i++){
        $dateArray[$i] = $dateTwoValues[$i][0];
    }
    $_SESSION["contractDateArray"] = $dateArray;

    for ($i = 0; $i < count($salaryTwoValues); $i++){
        $salaryArray[$i] = $salaryTwoValues[$i][0];
        //debug_to_console($afternoonArray[$i]);
    }
    $_SESSION["contractSalaryArray"] = $salaryArray;

    for ($i = 0; $i < count($departmentTwoValues); $i++){
        $departmentArray[$i] = $departmentTwoValues[$i][0];
    }
    $_SESSION["contractDepartmentArray"] = $departmentArray;

    for ($i = 0; $i < count($positionTwoValues); $i++){
    $positionArray[$i] = $positionTwoValues[$i][0];
    }
    $_SESSION["contractPositionArray"] = $positionArray;

}

getContractValues();
?>

<script>
    var myObjA;
    var nameA;
    var xmlhttpA = new XMLHttpRequest();
    xmlhttpA.onreadystatechange = function() {
        if (this.readyState == 4 && this.status == 200) {
            myObjA = JSON.parse(this.responseText);

            //adds the shifts from the array to the listbox
            for (let i = 0; i < myObjA.length; i++) {
                var para = document.createElement("p");
                var node = document.createTextNode(myObjA[i]);
                para.appendChild(node);
                var element = document.getElementById("contractDate");
                element.appendChild(para);
            }
        }
    };
    xmlhttpA.open("GET", "contractDateJSON.php", true);
    xmlhttpA.send();

    var myObjB;
    var nameB;
    var xmlhttpB = new XMLHttpRequest();
    xmlhttpB.onreadystatechange = function() {
        if (this.readyState == 4 && this.status == 200) {
            myObjB = JSON.parse(this.responseText);

            //adds the shifts from the array to the listbox
            for (let i = 0; i < myObjB.length; i++) {
                var para = document.createElement("p");
                var node = document.createTextNode(myObjB[i] + " €");
                para.appendChild(node);
                var element = document.getElementById("contractSalary");
                element.appendChild(para);
            }
        }
    };
    xmlhttpB.open("GET", "contractSalaryJSON.php", true);
    xmlhttpB.send();

    var myObjC;
    var nameC;
    var xmlhttpC = new XMLHttpRequest();
    xmlhttpC.onreadystatechange = function() {
        if (this.readyState == 4 && this.status == 200) {
            myObjC = JSON.parse(this.responseText);

            //adds the shifts from the array to the listbox
            for (let i = 0; i < myObjC.length; i++) {
                var para = document.createElement("p");
                var node = document.createTextNode(myObjC[i]);
                para.appendChild(node);
                var element = document.getElementById("contractDepartment");
                element.appendChild(para);
            }
        }
    };
    xmlhttpC.open("GET", "contractDepartmentJSON.php", true);
    xmlhttpC.send();

    var myObjD;
    var nameD;
    var xmlhttpD = new XMLHttpRequest();
    xmlhttpD.onreadystatechange = function() {
        if (this.readyState == 4 && this.status == 200) {
            myObjD = JSON.parse(this.responseText);

            //adds the shifts from the array to the listbox
            for (let i = 0; i < myObjD.length; i++) {
                var para = document.createElement("p");
                var node = document.createTextNode(myObjD[i]);
                para.appendChild(node);
                var element = document.getElementById("contractPosition");
                element.appendChild(para);
            }
        }
    };
    xmlhttpD.open("GET", "contractPositionJSON.php", true);
    xmlhttpD.send();
</script>

