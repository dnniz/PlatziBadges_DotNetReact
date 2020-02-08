import React from "react";

import "./styles/PageLoad.css";

function PageLoad() {
  return (
    <div className="PageLoading">
      <div className="lds-grid">
        <div></div>
        <div></div>
        <div></div>
        <div></div>
        <div></div>
        <div></div>
        <div></div>
        <div></div>
        <div></div>
      </div>
    </div>
  );
}

export default PageLoad;
