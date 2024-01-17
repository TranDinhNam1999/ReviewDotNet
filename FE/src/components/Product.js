import React, { useEffect, useState } from "react";
import { Button, Card, Form, InputGroup, Modal } from "react-bootstrap";
import ProductItem from "./ProductItem";
import { products as tmp } from "./products";
import CustomToast from "./Toast";
import "../index.css";

function Product(props) {
  const [query, setQuery] = useState("");
  const [products, setProducts] = useState([]);
  const [openAdd, setOpenAdd] = useState(false);
  const [data, setData] = useState({});
  const [alert, setAlert] = useState(false);

  const handleClose = () => {
    setData({});
    setOpenAdd(false);
  };

  const add = async () => {
    const response = await fetch("http://localhost:5034/api/Product", {
      method: "POST", // *GET, POST, PUT, DELETE, etc.
      body: JSON.stringify(data), // body data type must match "Content-Type" header
      headers: {
        "Content-Type": "application/json"
      }
    });
    return response.json();
  };

  const handleSaveProduct = async () => {
    if (data !== {}) {
      const rs = await add();
      console.log("rs: ", rs);

      console.log("data", data);
      setProducts([data, ...products]);
      setAlert(true);
      setTimeout(() => {
        setAlert(false);
      }, [2000]);
    }

    handleClose();
  };

  useEffect(() => {
    if (query) {
      const newProducts = products.filter((value) =>
        value.name.includes(query)
      );
      setProducts(newProducts);
    } else {
      fetch('http://localhost:5034/api/Product')
      .then((response) => response.json())
      .then((data) => 
        setProducts(data.items)
      )
    }
  }, [query]);

  return (
    <div>
      <h2 className="d-flex justify-content-between">
        <span>Products</span>{" "}
        <Button onClick={() => setOpenAdd(true)}>Add</Button>
      </h2>

      <InputGroup className="mb-3">
        <Form.Control
          placeholder="Filter products by name"
          aria-label="Username"
          aria-describedby="basic-addon1"
          value={query}
          onChange={(e) => setQuery(e.target.value)}
        />
        {/* <InputGroup.Text id="basic-addon1" onClick={() => handleSearch()} ></InputGroup.Text> */}
      </InputGroup>
      <div className="product-container">
        {products.map((value, key) => {
          return <ProductItem key={key} product={value} className="product-item" />;
        })}
      </div>

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
              <Form.Label>Price</Form.Label>
              <Form.Control
                onChange={(e) => setData({ ...data, price: e.target.value })}
                type="number"
                placeholder="Enter price"
              />
            </Form.Group>
          </Form>
        </Modal.Body>

        <Modal.Footer>
          <Button variant="secondary" onClick={handleClose}>
            Close
          </Button>
          <Button variant="primary" onClick={handleSaveProduct}>
            Save changes
          </Button>
        </Modal.Footer>
      </Modal>

      {alert && <CustomToast />}
    </div>
  );
}

export default Product;
