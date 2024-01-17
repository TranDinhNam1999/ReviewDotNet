import React, { useEffect, useState } from "react";
import { Button, Form, Modal, Table } from "react-bootstrap";
import CustomToast from "./Toast";
import { example_shops } from "./customersexample";

function Shop(props) {
  const [shops, setShops] = useState([]);
  const [openAdd, setOpenAdd] = useState(false);
  const [data, setData] = useState({});
  const [alert, setAlert] = useState(false);

  const handleClose = () => {
    setData({});
    setOpenAdd(false);
  };

  const add = async () => {
    const response = await fetch("http://localhost:5034/api/Shop", {
      method: "POST", // *GET, POST, PUT, DELETE, etc.
      body: JSON.stringify(data), // body data type must match "Content-Type" header
      headers: {
        "Content-Type": "application/json"
      }
    });
    return response.json();
  };

  const handleSaveShop = async () => {
    if (data !== {}) {
      const rs = await add();
      console.log("rs: ", rs);

      console.log("data", data);
      setShops([data, ...shops]);
      setAlert(true);
      setTimeout(() => {
        setAlert(false);
      }, [2000]);
    }

    handleClose();
  };

  useEffect(() => {
    fetch('http://localhost:5034/api/Shop')
    .then((response) => response.json())
    .then((data) => 
    setShops(data.items)
    )
  }, []);

  return (
    <>
      <h2 className="d-flex justify-content-between">
        <span>Shop</span>
        <Button onClick={() => setOpenAdd(true)}>Add</Button>
      </h2>
      <Table striped bordered hover>
        <thead>
          <tr>
            <th>#</th>
            <th>Name</th>
            <th>Location</th>
          </tr>
        </thead>
        <tbody>
          {shops.map((shop, key) => {
            return (
              <tr key={key}>
                <td>{key + 1}</td>
                <td>{shop.name}</td>
                <td>{shop.location}</td>
              </tr>
            );
          })}
        </tbody>
      </Table>

      <Modal show={openAdd} onHide={handleClose}>
        <Modal.Header closeButton>
          <Modal.Title>Create new product</Modal.Title>
        </Modal.Header>

        <Modal.Body>
          <Form>
            <Form.Group className="mb-3" controlId="formBasicPassword">
              <Form.Label>Name</Form.Label>
              <Form.Control
                onChange={(e) => setData({ ...data, name: e.target.value })}
                placeholder="Name"
              />
            </Form.Group>
            <Form.Group className="mb-3" controlId="formBasicEmail">
              <Form.Label>Location</Form.Label>
              <Form.Control
                onChange={(e) => setData({ ...data, location: e.target.value })}
                type="text"
                placeholder="Enter location"
              />
            </Form.Group>
          </Form>
        </Modal.Body>

        <Modal.Footer>
          <Button variant="secondary" onClick={handleClose}>
            Close
          </Button>
          <Button variant="primary" onClick={handleSaveShop}>
            Save changes
          </Button>
        </Modal.Footer>
      </Modal>

      {alert && <CustomToast />}
    </>
  );
}

export default Shop;
