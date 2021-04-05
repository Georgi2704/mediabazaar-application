<?php session_start(); ?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <link href="main.css" type="text/css" rel="stylesheet">
    <title>Media Bazaar - Hardware Store </title>
</head>
<body background ="mbImages/bck2small.jpg">
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
                    </li>
                </ul>
            </nav>
        </a>
    </div>
</header>
<div class = "logos">
    <p class="contactText">Contact manager's email:</p>
    <div>
        <a href="https://mail.google.com/mail/u/1">
        <img src="mbImages/glogo.png" width="200" height="150">
        <br>
    </div>
</div>
</body>
</html>