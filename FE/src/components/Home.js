import React, { useEffect, useState } from "react";
import Shop from "./Shop";
import Product from "./Product";
import { default_home_data } from "./customersexample";
import { Table } from "react-bootstrap";

function Home(props) {
  const [info, setInfo] = useState([]);

  useEffect(() => {
    fetch('http://localhost:5034/api/OrderDetail')
    .then((response) => response.json())
    .then((data) => 
      setInfo(data.items)
    );
  }, []);

  return (
    <div>
      <h2>Home</h2>
      <Table striped bordered hover>
        <thead>
          <tr>
            <th>#</th>
            <th>Customer</th>
            <th>Shop</th>
            <th>Product</th>
          </tr>
        </thead>
        <tbody>
          {info.map((c, index) => {
            return (
              <tr>
                <td>{index + 1}</td>
                <td>
                  {c.customerName}-{c.customerEmail}
                </td>
                <td>
                  {c.shopName}-{c.shopLocation}
                </td>
                <td>{c.productName}</td>
              </tr>
            );
          })}
        </tbody>
      </Table>
    </div>
  );
}

export default Home;
