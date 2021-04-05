<?php session_start(); ?>
<!DOCTYPE html>
<html>
<head>
    <link rel="stylesheet" type="text/css" href="login.css">
    <title>Login - Media Bazaar</title>
</head>
<body>
<img class="logo" src="mbImages/logologin.jpg">
<h1>Sign In</h1>
<form method="post">
    <div class="container2">
        <div class="tbUserInput">
            <label for="uname"><b>Username:</b></label>
            <input class="textboxInside" type="text" placeholder="First Name" name="uname" required>
            <br>
            </div>
        <div class="tbUserInput">
            <label for="psw"><b>Password :</b></label>
            <input class="textboxInside" type="password" placeholder="Password" name="psw" required>
            <br>
            </div>
        <div class="btnLogin">
            <button type="submit" name="login_user">Login</button>
        </div>
    </div>
    <div class="container2" style="backface-visibility: visible">
        
    </div>
    </form>
</body>
</html>
    <?php

    if (isset($_SESSION["loggedin"]) && $_SESSION["loggedin"] === true) {
        header("location: HomePage.php");
     }

if(isset($_POST['login_user'])){
    $_SESSION["logged_in"] = false;
include 'ServerSettings.php';

    $conn = new PDO("mysql:host=$servername;dbname=$database", $username, $password);
    $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);


$queryusername = $_POST["uname"];
$querypassword = $_POST["psw"];
$sql ='SELECT * FROM employee WHERE username = :username AND pass= :pword';
$stmt = $conn->prepare($sql);
$stmt->execute(
	[
		':username'=> $queryusername,
        ':pword' => $querypassword
	]
);
$result = $stmt->fetch();
if($stmt->rowCount() > 0)
{
$_SESSION["loggedin"] = true;
$sql2 ='SELECT * FROM employee WHERE username = :username';
$stmt2 = $conn->prepare($sql2);
$stmt2->execute(
	[
		':username'=> $queryusername,
    ]
);
$resultt = $stmt2->fetch();
$_SESSION['id'] = $result["employeeID"];
$_SESSION['pass'] = $result["pass"];
$_SESSION['fname'] = $resultt["firstName"];
$_SESSION['phoneNr'] = $resultt["phone"];
$_SESSION['address'] = $resultt["address"];
$_SESSION['contactFirstName'] = $resultt["contactFirstName"];
$_SESSION['contactPhone'] = $resultt["contactPhone"];
$_SESSION['salary'] = $resultt["salary"];
$_SESSION['position'] = $resultt["position"];
$_SESSION['lname'] = $resultt["lastName"];
$_SESSION['username'] = $resultt["username"];
$_SESSION['birthDate'] = $result["dateOfBirth"];
$_SESSION['department'] = $resultt["departmentName"];

$personid = $_SESSION['id'];

$sql3 ='SELECT * FROM employee WHERE employeeID = :personid';
$stmt3 = $conn->prepare($sql3);
$stmt3->execute(
    [
        ':personid'=> $personid,
    ]
);
$resultProfiles = $stmt3->fetch();


header('Location:HomePage.php');
}
else{

    $message = "You have entered the wrong password";
    echo "<script type='text/javascript'>alert('$message');</script>";
}
$conn = null;

    }
?>
