import React from "react";
import { Link } from "react-router-dom";

import LogoConf from "../images/platziconf-logo.svg";
import "./styles/BadgeDetails.css";
import Badge from "../components/Badge";

import DeleteBadgeModel from "../components/DeleteBadgeModal";

function BadgeDetails(props) {
  return (
    <React.Fragment>
      <div className="BadgeDetails__hero">
        <div className="container">
          <div className="row">
            <div className="col-6">
              <img src={LogoConf} alt="logo de conferencia" />
            </div>
            <div className="col-6 BadgeDetails__hero-attendant-name">
              <h1>
                {props.badge.firstName} {props.badge.lastName}
              </h1>
            </div>
          </div>
        </div>
      </div>

      <div className="container">
        <div className="row">
          <div className="col-md-6">
            <Badge
              firstName={props.badge.firstName}
              lastName={props.badge.lastName}
              jobTitle={props.badge.jobTitle}
              twitter={props.badge.twitter}
              email={props.badge.email}
            />
          </div>
          <div className="col-md-6 text-center">
            <h2>Actions</h2>
            <div>
              <div>
                <Link
                  className="btn btn-primary mb-4"
                  to={`/badges/${props.badge.badgeId}/edit`}
                >
                  Edit
                </Link>
              </div>
              <div>
                <button onClick={props.onClick} className="btn btn-danger">
                  Delete
                </button>
                <DeleteBadgeModel
                  modelIsOpen={props.modelIsOpen}
                  onClick={props.onClick}
                  onClickDelete={props.onClickDelete}
                />
              </div>
            </div>
          </div>
        </div>
      </div>
    </React.Fragment>
  );
}

export default BadgeDetails;
