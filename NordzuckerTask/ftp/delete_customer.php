<?php
    require_once "connect.php";
    
    if(isset($_POST['Customer_ID']))
    {
        $customerID = $_POST['Customer_ID'];
        
        $conn = new mysqli($host,$db_user,$db_password,$db_name);
    
        if($conn->connect_errno != 0)
        {
            echo "Error: ".$conn->connect_errno;
        }
        else
        {
            $sql = "delete from Customers where Customer_ID = ".$customerID;
            if($result = mysqli_query($conn,$sql))
            {
                print_r('Customer has been deleted');
            }
            else print_r('false');
            mysqli_close($conn);
        }
    }
    
?>
