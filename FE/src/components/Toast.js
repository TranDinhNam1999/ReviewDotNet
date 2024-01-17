import React from "react";
import { Toast, ToastContainer } from "react-bootstrap";

function CustomToast(props) {
  return (
    <ToastContainer position="bottom-end" className="p-3" style={{ zIndex: 1 }}>
      <Toast className="d-inline-block m-1" bg="success">
        <Toast.Header>
          <img src="holder.js/20x20?text=%20" className="rounded me-2" alt="" />
          <strong className="me-auto">Success</strong>
          <small>0 second ago</small>
        </Toast.Header>
        <Toast.Body className="text-white">Add item success</Toast.Body>
      </Toast>
    </ToastContainer>
  );
}

export default CustomToast;
