Create table  branddetails  (  brandname varchar(50)  primary key, contractstartdate date ,
  totalnoofyearcontract  int,brandlogo image  );



  Create table productstockdetails ( productname varchar(50),brandname varchar(50) references  branddetails (  brandname ),productprice int,
 noofitemsavailable int ,  productimage  image, productcategory varchar(50),
constraint  pk_prod_brand  primary key( productname, brandname  ) );


create table productoffersdetails(productname varchar(50),brandname varchar(50) ,discount int ,productspecialoffer varchar(400) , constraint fk_prod_brand foreign key(productname, brandname)   
 references  productstockdetails(  productname, brandname ));


 create table customers(custid varchar(50) primary key, custname varchar(50), custemail varchar(50),
 custcontactno varchar(20));


 create  table  billdetails (  custid varchar(50)  references customers(custid),
   productname varchar(50),brandname varchar(50),  noofproduct  int , totalbill int ,billdate date );




