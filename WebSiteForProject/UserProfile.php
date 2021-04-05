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
<div class="galleryBody">
    <div class="titleRow">
        <div class="myProfileTitle">
            <h1>Employee Profile</h1>
        </div>
        <img src="mbImages/pngkit_construction-worker-png_699859.png" class="profilePicture">
    </div>
    <div class="rowProfile">

        <div class="profileInfo">
            <p style="color:white">Full Name: <span
                    style="color: black;"><?php echo "{$_SESSION['fname'] }  {$_SESSION['lname']}"?></span></p>
            <p style="color:white">Username: <span
                    style="color: black;"><?php echo $_SESSION['username'] ?></span></p>
            <p style="color:white">Department: <span
                    style="color: black;"><?php echo $_SESSION['department'] ?></span></p>
            <p style="color:white">Phone Number: <span
                    style="color: black;"><?php echo $_SESSION['phoneNr'] ?></span></p>
            <p style="color:white">Address: <span
                    style="color: black;"><?php echo $_SESSION['address'] ?></span></p>
            <p style="color:white">Emergency Contact: <span
                    style="color: black;"><?php echo $_SESSION['contactFirstName'] ?></span></p>
            <p style="color:white">Emergency Contact Phone: <span
                    style="color: black;"><?php echo $_SESSION['contactPhone'] ?></span></p>
            <p style="color:white">Position: <span
                    style="color: black;"><?php echo $_SESSION['position'] ?></span></p>
            <p style="color:white">Salary: <span
                    style="color: black;"><?php echo $_SESSION['salary'] ?></span></p>
            <p style="color:white">Age: <span
                    style="color: black;"><?php
                    if(getAge($_SESSION['birthDate']) > 0){
                        echo getAge($_SESSION['birthDate']);
                    }else{
                        echo 1;
                    }
                    ?></span></p>


        </div>
    </div>
    <div class="myProfileTitle">
        <h1>Shift Details:</h1>
        <h2 id="currentMonth"> Selected month: -</h2>
    </div>
    <div class="rowProfile">
        <div class="shiftInfo">
            <div class="shiftColumn">
                <form name ="lbUserList" Method="post" action="UserProfile.php">
                    <p class="shiftname"> Your Shifts:</p>
                    <select class="lbox" name="taskOption" size="5" id="combined">
                        <!-- Dates will be here -->
                    </select>

                </form>
            </div>
            <div class="shiftColumn">
                <p class="shiftname"> Select Month:</p>
                <form name ="cbxMonths" Method="post" action="UserProfile.php">
                    <select name="selectMonths" id="months">
                        <option value="January">January</option>
                        <option value="February">February</option>
                        <option value="March">March</option>
                        <option value="April">April</option>
                        <option value="May">May</option>
                        <option value="June">June</option>
                        <option value="July">July</option>
                        <option value="August">August</option>
                        <option value="September">September</option>
                        <option value="October">October</option>
                        <option value="November">November</option>
                        <option value="December">December</option>
                    </select>
                    <div class="container">
                        <button type="submit" class="btn" id = "selectMonth" name="buttonSelectMonth">Select Month</button>
                    </div>
                </form>
            </div>
        </div>
    </div>
</div>
<footer class="footer">All rights reserved (c) 2020 George Manev</footer>

<script>
    //Gets the array that is JSON encoded from AllShiftsJSON.php
    var myObjC;
    var nameC;
    var xmlhttpC = new XMLHttpRequest();
    xmlhttpC.onreadystatechange = function() {
        if (this.readyState == 4 && this.status == 200) {
            myObjC = JSON.parse(this.responseText);

            //adds the shifts from the array to the listbox
            for (let i = 0; i < myObjC.length; i++) {
                var para = document.createElement("option");
                var node = document.createTextNode(myObjC[i]);
                para.appendChild(node);
                var element = document.getElementById("combined");
                element.appendChild(para);
            }
        }
    };
    xmlhttpC.open("GET", "AllShiftsJSON.php", true);
    xmlhttpC.send();

</script>

</body>
<?php

//function for debugging php code
function debug_to_console($data) {
    $output = $data;
    if (is_array($output))
        $output = implode(',', $output);

    echo "<script>console.log('Debug Objects: " . $output . "' );</script>";
}
include 'QueryDates.php';
function getNames(){
    $morningTwoValues = GetMorningDates();
    $afternoonTwoValues = GetAfternoonDates();
    $eveningTwoValues = GetEveningDates();
    $morningArray = array();
    $afternoonArray = array();
    $eveningArray = array();

    //Convert the associative array into indexed array
    for ($i = 0; $i < count($morningTwoValues); $i++){
        $morningArray[$i] = $morningTwoValues[$i][0];
    }
    $_SESSION["morningArray"] = $morningArray;
    //afternoon shifts array
    for ($i = 0; $i < count($afternoonTwoValues); $i++){
        $afternoonArray[$i] = $afternoonTwoValues[$i][0];
        //debug_to_console($afternoonArray[$i]);
    }
    $_SESSION["afternoonArray"] = $afternoonArray;
    //evening shifts array
    for ($i = 0; $i < count($eveningTwoValues); $i++){
        $eveningArray[$i] = $eveningTwoValues[$i][0];
        debug_to_console($eveningArray[$i]);
    }
    $_SESSION["eveningArray"] = $eveningArray;
}


function getAge($date) { // Y-m-d format
    return intval(substr(date('Ymd') - date('Ymd', strtotime($date)), 0, -4));
}
$_SESSION["selectMonthsGlobal"] = "May";
if (isset($_POST["buttonSelectMonth"])) {
    $option = isset($_POST['selectMonths']) ? $_POST['selectMonths'] : false;
    if ($option) {
        $_SESSION["selectMonthsGlobal"] = $_POST['selectMonths'];
        $test = $_SESSION["selectMonthsGlobal"];
        $test2 = CheckMonth($test);
        //debug_to_console($test2);
        //DeleteUser($_POST['taskOption']);
    } else {
        echo "<script type='text/javascript'>alert('Please choose a user from the list');</script>";
        exit;
    }
}
getNames();
?>
</html>

<script>
    document.getElementById("currentMonth").innerHTML = "Selected Month: <?php echo $_SESSION["selectMonthsGlobal"] ?>";
</script>
