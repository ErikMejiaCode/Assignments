const express = require("express");
const { faker } = require('@faker-js/faker');
const app = express();


class User {
  constructor(){
    this.id = faker.datatype.number();
    this.firstName = faker.name.firstName();
    this.lastName = faker.name.lastName();
    this.phoneNumber = faker.phone.number();
    this.email = faker.internet.email();
    this.password = faker.internet.password();
  }
}
const newUser = new User();
console.log(newUser)


class Address {
  constructor(){
    this.street = faker.address.streetAddress();
    this.city = faker.address.city();
    this.state = faker.address.state();
    this.zipCode = faker.address.zipCode();
    this.country = faker.address.country();
  }
}
const newAddress = new Address();

class Company {
  constructor(){
    this._id = faker.datatype.number();
    this.name = faker.company.name();
    this.address = newAddress;
  }
}
const newCompany = new Company();
console.log(newCompany)



//GET USER 
app.get("/api/users/new", (req, res) => {
    res.json({
      message: "New User Created",
      status: "success",
      User: newUser
    })
})


//GET COMPANY 
app.get("/api/companies/new", (req, res) => {
  res.json({
    message: "New Company has been created",
    status: "success",
    Company: newCompany
  })
})


//GET NEW USER & COMPANY 
app.get("/api/user/company/new", (req, res) => {
  res.json({
    message: "New User & Company created",
    status: "Success",
    User: newUser,
    Company: newCompany
  })
})


// req is short for request
// res is short for response
app.get("/api", (req, res) => {
  res.send("Our express api server is now sending this over to the browser");
});








const server = app.listen(8000, () =>
  console.log(`Server is locked and loaded on port ${server.address().port}!`)
);
