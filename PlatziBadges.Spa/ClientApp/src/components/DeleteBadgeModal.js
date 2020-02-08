import React from "react";
import Modal from "./Modal";

function DeleteBadgeModel(props) {
  return (
    <Modal modelIsOpen={props.modelIsOpen} onClick={props.onClick}>
      <div className="DeleteBadgeModal">
        <h1>Are you sure?</h1>
        <p>You are about to delete this badge.</p>
        <div className="btn-group">
          <button className="btn btn-danger" onClick={props.onClickDelete}>
            Delete
          </button>
          <button className="btn btn-secondary" onClick={props.onClick}>
            Cancel
          </button>
        </div>
      </div>
    </Modal>
  );
}

export default DeleteBadgeModel;
