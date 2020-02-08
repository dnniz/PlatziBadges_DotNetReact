import React from "react";
import { Link } from "react-router-dom";

import api from "../api";
import "./styles/Badges.css";
import BadgesList from "../components/BadgesList";
import PageLoad from "../components/PageLoad";
import BadgeHeroes from "../components/BadgeHeroes";
import NotFound from "../components/NotFound";
import confLogo from "../images/badge-header.svg";

class Badges extends React.Component {
  constructor(props) {
    super(props);
    console.log("1. constructor()");

    this.state = {
      loading: true,
      error: null,
      data: undefined
    };
  }

  handleRedirectEdit = badgeId => {
    console.log(badgeId);
    this.props.history.push(`/badges/${badgeId}`);
  };

  render() {
    if (this.state.loading) {
      return (
        <React.Fragment>
          <BadgeHeroes logo={confLogo} />
          <PageLoad />
        </React.Fragment>
      );
    }
    if (this.state.error) {
      return (
        <NotFound error={this.state.error} message={this.state.error.message} />
      );
    }
    console.log("2/4. render()");
    return (
      <React.Fragment>
        <BadgeHeroes logo={confLogo} />
        <div className="Badges__container">
          <div className="Badges__buttons">
            <Link to="/badges/new" className="btn btn-primary">
              New Badge
            </Link>
          </div>
          <BadgesList
            badges={this.state.data}
            redirectEdit={this.handleRedirectEdit}
          />
        </div>
      </React.Fragment>
    );
  }

  componentDidMount() {
    console.log("3. componentDidMount()");
    this.fetchData();
  }

  fetchData = async () => {
    this.setState({ loading: true, error: null });

    try {
      const data = await api.badges.list();
      console.log(data);
      this.setState({ loading: false, data: data });
    } catch (error) {
      this.setState({ loading: false, error: error });
    }
  };

  componentDidUpdate(prevProps, prevState) {
    console.log("5. componentDidUpdate()");
    /* DELETE: */
    // console.log({
    //   prevProps: prevProps,
    //   prevState: prevState
    // });

    // console.log({
    //   props: this.props,
    //   state: this.state
    // });
  }

  componentWillUnmount() {
    console.log("6. componentWillMount()");

    clearTimeout(this.timeOutId);
  }
}

export default Badges;
