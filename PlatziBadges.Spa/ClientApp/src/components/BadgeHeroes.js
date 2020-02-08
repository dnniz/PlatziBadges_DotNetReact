import React from "react";

import "../pages/styles/Badges.css";

class BadgeHeroes extends React.Component {
  render() {
    return (
      <div className="Badges">
        <div className="Badges__hero">
          <div className="Badges__container">
            <img
              className="Badges_conf-logo"
              src={this.props.logo}
              alt="logo conf"
            />
          </div>
        </div>
      </div>
    );
  }
}

export default BadgeHeroes;
