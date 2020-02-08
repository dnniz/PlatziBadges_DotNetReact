import React from "react";

import api from "../api";
import LogoConf from "../images/platziconf-logo.svg";
import "./styles/BadgeDetails.css";
import BadgeHeroes from "../components/BadgeHeroes";
import PageLoad from "../components/PageLoad";
import NotFound from "../components/NotFound";
import BadgeDetails from "./BadgeDetails";

class BadgeDetailsContainer extends React.Component {
  state = {
    modalOpen: false,
    loading: true,
    error: null,
    data: undefined
  };

  componentDidMount() {
    this.fetchData();
  }

  handleOnChangeModal = () => {
    this.setState({
      modalOpen: !this.state.modalOpen
    });
  };

  handleOnClickDelete = async () => {
    this.setState({ loading: true, error: null });

    try {
      const badgeId = this.props.match.params.badgeId;

      await api.badges.remove(badgeId);

      this.props.history.push("/badges");

      this.setState({ loading: false });
    } catch (error) {
      this.setState({ loading: false, error: error });
    }
  };

  render() {
    if (this.state.loading) {
      return (
        <React.Fragment>
          <BadgeHeroes logo={LogoConf} />
          <PageLoad />
        </React.Fragment>
      );
    }

    if (this.state.error) {
      return (
        <React.Fragment>
          <NotFound />
        </React.Fragment>
      );
    }

    return (
      <BadgeDetails
        badge={this.state.data}
        onClick={this.handleOnChangeModal}
        modelIsOpen={this.state.modalOpen}
        onClickDelete={this.handleOnClickDelete}
      />
    );
  }

  fetchData = async () => {
    this.setState({ loading: true, error: null });

    try {
      const data = await api.badges.read(this.props.match.params.badgeId);

      //Si el objeto devuelto esta vacío
      if (Object.keys(data).length === 0) {
        this.props.history.push("/NotFound");
        return;
      }

      this.setState({
        loading: false,
        data: data
      });
    } catch (error) {
      this.setState({
        loading: false,
        error: error
      });
    }
  };
}

export default BadgeDetailsContainer;
