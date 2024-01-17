import React from "react";
import { Button, Card } from "react-bootstrap";

function ProductItem({ product }) {
  return (
    <Card style={{ width: "15rem" }}>
      {/* <Card.Img
        variant="top"
        src="https://www.searchenginejournal.com/wp-content/uploads/2022/06/image-search-1600-x-840-px-62c6dc4ff1eee-sej.png"
      /> */}
      <Card.Body>
        <Card.Title>{product.name}</Card.Title>
        <Card.Text>{product.price}</Card.Text>
        {/* <Button variant="primary">Order</Button> */}
      </Card.Body>
    </Card>
  );
}

export default ProductItem;
