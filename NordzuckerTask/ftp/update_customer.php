<?php
    require_once "connect.php";
    
    if(isset($_POST['Customer_ID']) && isset($_POST['Customer_Name']) && isset($_POST['Customer_Surname']) && isset($_POST['Customer_Login']) && isset($_POST['Customer_Password']))
    {
        $customerID = $_POST['Customer_ID'];
        $customerName = $_POST['Customer_Name'];
        $commentSurname = $_POST['Customer_Surname'];
        $customerLogin = $_POST['Customer_Login'];
        $customerPassword = $_POST['Customer_Password'];
        
        $conn = new mysqli($host,$db_user,$db_password,$db_name);
        
        if($conn->connect_errno != 0)
        {
            echo "Error: ".$conn->connect_errno;
        }
        else
        {
            $sql = "update Customers set Customer_Name = '".$customerName."', Customer_Surname = '".$commentSurname."', Customer_Login = '".$customerLogin."', Customer_Password = '".$customerPassword."' where Customer_ID = ".$customerID;
            if($result = mysqli_query($conn,$sql))
            {
                print_r("Customer has been updated");
            }
            else print_r('false');
            mysqli_close($conn);
        }
    }
?>
