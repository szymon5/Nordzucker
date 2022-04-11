<?php
    require_once "connect.php";
    
    if(isset($_POST['Login']) && isset($_POST['Password']))
    {
        $login = $_POST['Login'];
        $password = $_POST['Password'];
        
        $login = htmlentities($login,ENT_QUOTES,"UTF-8");
        $password = htmlentities($password,ENT_QUOTES,"UTF-8");
        
        $conn = new mysqli($host,$db_user,$db_password,$db_name);
        
        if($conn->connect_errno != 0)
        {
            echo "Error: ".$conn->connect_errno;
        }
        else
        {
            if($result = $conn->query(
               sprintf("select Customer_ID from Users where Customer_Login='%s' and Customer_Password='%s'",
               mysqli_real_escape_string($conn,$login),
               mysqli_real_escape_string($conn,$password))))
            {
                if($result->num_rows == 1)
                {
                    $row = $result->fetch_assoc();
                    print_r($row['ID']);
                }
                else print_r("Login failed");
            }
            $conn->close();
        }
    }
?>
