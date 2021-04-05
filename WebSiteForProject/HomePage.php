<?php session_start(); ?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <link href="main.css" type="text/css" rel="stylesheet">
    <title>Media Bazaar - Hardware Store</title>
</head>
<body background="mbImages/bck2small.jpg">
<header>
    <div class="menu">
        <nav>
        <ul>
            <li><a href="Logout.php">Log Out</a></li>
            <li><a href="HomePage.php">Home</a></li>
            <li><a href="ContactManager.php">Contact manager</a></li>
            <li><a href="Contracts.php">View my contracts</a></li>
            <li><a href="UserProfile.php" >
                Profile and Shifts - <?php
                    echo "{$_SESSION['fname'] }  {$_SESSION['lname']}"
                    ?>
                </a>
            </li>
        </ul>
        </nav>
            <a href="HomePage.php"><img src="mbImages/mediabazaar.png" alt="logo" class="logo">
        </a>
    </div>
</header>
<div class="homePageContent">
    <h1>Media Bazaar Hardware Store</h1>
    <h2 id="welcome" >Welcome, <?php
        echo "{$_SESSION['fname'] }  {$_SESSION['lname']}"
        ?></h2>
    <div class="homePageParagraphs">

    </div>
</div>

</body>
</html>
