import React, { useEffect, useState } from "react";
import { Button, Form, Modal, Table } from "react-bootstrap";
import { customer_example } from "./customersexample";
import CustomToast from "./Toast";

function Customer(props) {
  const [customers, setCustomers] = useState([]);
  const [openAdd, setOpenAdd] = useState(false);
  const [data, setData] = useState({});
  const [alert, setAlert] = useState(false);

  useEffect(() => {
    fetch('http://localhost:5034/api/Customer')
    .then((response) => response.json())
    .then((data) => 
      setCustomers(data.items)
    )
  }, []);

  const handleClose = () => {
    setData({});
    setOpenAdd(false);
  };

  const add = async () => {
    const response = await fetch("http://localhost:5034/api/Customer", {
      method: "POST", // *GET, POST, PUT, DELETE, etc.
      body: JSON.stringify(data), // body data type must match "Content-Type" header
      headers: {
        "Content-Type": "application/json"
      }
    });
    return response.json();
  };

  const handleSaveCustomer = async () => {
    if (data !== {}) {
      const rs = await add();
      console.log("rs: ", rs);

      console.log("data", data);
      setCustomers([data, ...customers]);
      setAlert(true);
      setTimeout(() => {
        setAlert(false);
      }, [2000]);
    }

    handleClose();
  };

  return (
    <div>
      <h2 className="d-flex justify-content-between">
        <span>Customer</span>{" "}
        <Button onClick={() => setOpenAdd(true)}>Add</Button>
      </h2>
      <Table striped bordered hover>
        <thead>
          <tr>
            <th>#</th>
            <th>Name</th>
            <th>Email</th>
            <th>Date of birth</th>
          </tr>
        </thead>
        <tbody>
          {customers.map((c, index) => {
            const date = new Date(c.dateOfBirth);

            const options = { month: "long", day: "numeric", year: "numeric" };
            const formattedDate = date.toLocaleDateString("en-US", options);

            // console.log(formattedDate); // Output: May 15, 1985

            return (
              <tr>
                <td>{index + 1}</td>
                <td>{c.fullName}</td>
                <td>{c.email}</td>
                <td>{formattedDate}</td>
              </tr>
            );
          })}
        </tbody>
      </Table>

      <Modal show={openAdd} onHide={handleClose}>
        <Modal.Header closeButton>
          <Modal.Title>Create new customer</Modal.Title>
        </Modal.Header>

        <Modal.Body>
          <Form>
            <Form.Group className="mb-3" controlId="formBasicPassword">
              <Form.Label>Name</Form.Label>
              <Form.Control
                onChange={(e) => setData({ ...data, fullName: e.target.value })}
                placeholder="Name"
              />
            </Form.Group>
            <Form.Group className="mb-3" controlId="formBasicEmail">
              <Form.Label>Email address</Form.Label>
              <Form.Control
                onChange={(e) => setData({ ...data, email: e.target.value })}
                type="email"
                placeholder="Enter email"
              />
              <Form.Text className="text-muted">
                We'll never share your email with anyone else.
              </Form.Text>
            </Form.Group>

            <Form.Group className="mb-3" controlId="formBasicPassword">
              <Form.Label>Date of birth</Form.Label>
              <Form.Control
                onChange={(e) =>
                  setData({ ...data, dateOfBirth: e.target.value })
                }
                type="date"
                placeholder="Date of birth"
              />
            </Form.Group>
          </Form>
        </Modal.Body>

        <Modal.Footer>
          <Button variant="secondary" onClick={handleClose}>
            Close
          </Button>
          <Button variant="primary" onClick={handleSaveCustomer}>
            Save changes
          </Button>
        </Modal.Footer>
      </Modal>

      {alert && <CustomToast />}
    </div>
  );
}

export default Customer;
