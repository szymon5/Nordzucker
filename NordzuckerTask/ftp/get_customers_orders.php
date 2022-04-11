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
            $sql = "SELECT Articles.Article_ID,Articles.Article_IMG,Articles.Article_Name,Articles.Article_Price_PLN,
                    Orders.Article_Quantity
                    FROM Orders,Customers,Articles
                    WHERE Orders.Customer_ID = ".$customerID." and Customers.Customer_ID = Orders.Customer_ID and Orders.Article_ID = Articles.Article_ID";
            if($result = mysqli_query($conn,$sql))
            {
                $userArray = array();
                while($row = mysqli_fetch_assoc($result))
                {
                    $user_data = array("Article_ID" => $row['Article_ID'],
                                      "Article_IMG" => $row['Article_IMG'],
                                      "Article_Name" => $row['Article_Name'],
                                      "Article_Price_PLN" => $row['Article_Price_PLN'],
                                      "Article_Quantity" => $row['Article_Quantity']);
                    array_push($userArray,$user_data);
                    
                }
                echo json_encode($userArray);
            }
            else print_r('false');
            mysqli_close($conn);
        }
    }
?>
