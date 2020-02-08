import React from "react";
import { Link } from "react-router-dom";

import "./styles/NotFound.css";

class NotFound extends React.Component {
  render() {
    return (
      <div className="notFound">
        <div className="container">
          <div className="row">
            <div className="offset-md-2 col-md-8 text-center">
              {this.props.error ? (
                <React.Fragment>
                  <h1>{this.props.message}</h1>
                  <p>Internal Server Error</p>
                </React.Fragment>
              ) : (
                <React.Fragment>
                  <h1>404: Not Found</h1>
                  <p>¡Ups! La página solicitada no fue encontrada</p>
                </React.Fragment>
              )}
              <Link className="btn btn-primary" to="/">
                Return to Home
              </Link>
            </div>
          </div>
        </div>
      </div>
    );
  }
}

export default NotFound;
