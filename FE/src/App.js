import logo from "./logo.svg";
import "./App.css";
import SideNav from "./components/SideNav";
import { useState } from "react";
import Button from "react-bootstrap/Button";
import Offcanvas from "react-bootstrap/Offcanvas";
import "bootstrap/dist/css/bootstrap.min.css";
import { ListGroup } from "react-bootstrap";
import Shop from "./components/Shop";
import Product from "./components/Product";
import Customer from "./components/Customer";
import Home from "./components/Home";

const PAGES = [
  {
    name: "Customer",
    value: 1,
  },
  {
    name: "Shop",
    value: 1,
  },
  {
    name: "Product",
    value: 1,
  },
];

function App() {
  const [page, setPage] = useState(4);

  return (
    <div className="App d-flex">
      <nav className="col-3">
        <ListGroup>
          <Button onClick={() => setPage(4)}>Home</Button>
          <ListGroup.Item>
            <p className="" onClick={() => setPage(1)}>
              Customer
            </p>
          </ListGroup.Item>
          <ListGroup.Item>
            <p onClick={() => setPage(2)}>Shop</p>
          </ListGroup.Item>
          <ListGroup.Item>
            <p onClick={() => setPage(3)}>Product</p>
          </ListGroup.Item>
        </ListGroup>
      </nav>
      <main className="col-9">
        {page === 1 && <Customer />}
        {page === 2 && <Shop />}
        {page === 3 && <Product />}
        {page === 4 && <Home />}
      </main>
    </div>
  );
}

export default App;
