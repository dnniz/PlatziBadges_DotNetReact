import React from "react";
import { Link } from "react-router-dom";

import "../components/styles/Badge.css";

class BadgeForm extends React.Component {
  handleChange = e => {
    this.setState({
      [e.target.name]: e.target.value
    });
  };

  // handleClick = () => {
  //   console.log("Button was click");
  // };

  render() {
    return (
      <React.Fragment>
        <form onSubmit={this.props.onSubmit}>
          <div className="form-group">
            <label>First Name</label>
            <input
              onChange={this.props.onChange}
              value={this.props.formValues.firstName}
              className="form-control"
              type="text"
              name="firstName"
            />
          </div>
          <div className="form-group">
            <label>Last Name</label>
            <input
              onChange={this.props.onChange}
              value={this.props.formValues.lastName}
              className="form-control"
              type="text"
              name="lastName"
            />
          </div>
          <div className="form-group">
            <label>Email</label>
            <input
              onChange={this.props.onChange}
              value={this.props.formValues.email}
              className="form-control"
              type="email"
              name="email"
            />
          </div>
          <div className="form-group">
            <label>Job Title</label>
            <input
              onChange={this.props.onChange}
              value={this.props.formValues.jobTitle}
              className="form-control"
              type="text"
              name="jobTitle"
            />
          </div>
          <div className="form-group">
            <label>Twitter</label>
            <input
              onChange={this.props.onChange}
              value={this.props.formValues.twitter}
              className="form-control"
              type="text"
              name="twitter"
            />
          </div>
          <div className="btn-group">
            {/* <Link className="btn btn-secondary" to="/Badges">
              List Badges
            </Link> */}
            <button
              // onClick={this.handleClick}
              className="btn btn-primary"
            >
              Save
            </button>
          </div>
        </form>
        {this.props.error && (
          <p className="text-danger">{this.props.error.message}</p>
        )}
      </React.Fragment>
    );
  }
}

export default BadgeForm;
