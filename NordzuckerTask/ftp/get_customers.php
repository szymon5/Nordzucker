<?php
    require_once "connect.php";
    
    $conn = new mysqli($host,$db_user,$db_password,$db_name);
        
    if($conn->connect_errno != 0)
    {
        echo "Error: ".$conn->connect_errno;
    }
    else
    {
        $sql = "select * from Customers";
        if($result = mysqli_query($conn,$sql))
        {
            $userArray = array();
            while($row = mysqli_fetch_assoc($result))
            {
                $user_data = array("ID" => $row['Customer_ID'],
                                  "Profile_IMG" => $row['Customer_Profile_IMG'],
                                  "Name" => $row['Customer_Name'],
                                  "Surname" => $row['Customer_Surname'],
                                  "Login" => $row['Customer_Login'],
                                  "Password" => $row['Customer_Password']);
                array_push($userArray,$user_data);
                
            }
            echo json_encode($userArray);
        }
        else print_r('false');
        mysqli_close($conn);
    }
?>
