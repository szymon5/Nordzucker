<?php
    require_once "connect.php";
    
    if(isset($_POST['Customer_Name']) && isset($_POST['Customer_Surname']) && isset($_POST['Customer_Login']) && isset($_POST['Customer_Password']))
    {
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
            $sql = "insert into Customers(Customer_Profile_IMG,Customer_Name,Customer_Surname,Customer_Login,Customer_Password) 
            values('https://serwer2197691.home.pl/nordzucker/customer_img.jpg','".$customerName."','".$commentSurname."','".$customerLogin."','".$customerPassword."')";
            if($result = mysqli_query($conn,$sql))
            {
                print_r("Customer has been added");
            }
            else print_r('false');
            mysqli_close($conn);
        }
    }
?>
