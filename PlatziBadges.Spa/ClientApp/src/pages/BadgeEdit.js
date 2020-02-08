import React from "react";

import "./styles/BadgeNew.css";
import Badge from "../components/Badge.js";
import BadgeForm from "../components/BadgeForm.js";
import BadgeHeroes from "../components/BadgeHeroes";
import confLogo from "../images/platziconf-logo.svg";
import api from "../api";
import md5 from "md5";
import PageLoad from "../components/PageLoad";

class BadgeEdit extends React.Component {
  state = {
    loading: true,
    error: null,
    data: undefined,
    form: {
      firstName: "",
      lastName: "",
      jobTitle: "",
      twitter: "",
      email: "",
      avatarUrl: ""
    }
  };

  handleChange = e => {
    this.setState({
      form: {
        ...this.state.form,
        [e.target.name]: e.target.value
      }
    });
  };

  handleSubmit = async e => {
    e.preventDefault();
    this.setState({ loading: true, error: null });
    try {
      this.state.form.avatarUrl = `https://s.gravatar.com/avatar/${md5(
        this.state.form.email
      )}?s=80`;

      await api.badges.update(this.props.match.params.badgeId, this.state.form);
      this.setState({ loading: false });

      this.props.history.push("/badges");
    } catch (error) {
      this.setState({ loading: false, error: error });
    }
  };

  componentDidMount() {
    this.fetchData();
  }

  render() {
    if (this.state.loading) {
      return (
        <React.Fragment>
          <BadgeHeroes logo={confLogo} />
          <PageLoad />
        </React.Fragment>
      );
    }

    return (
      <React.Fragment>
        <BadgeHeroes logo={confLogo} />

        <div className="container">
          <div className="row">
            <div className="col">
              <Badge
                firstName={this.state.form.firstName || "First_Name"}
                lastName={this.state.form.lastName || "Last_Name"}
                jobTitle={this.state.form.jobTitle || "Job_Title"}
                twitter={this.state.form.twitter || "twitter"}
                email={this.state.form.email || "EMAIL"}
              />
            </div>
            <div className="col-sm-6">
              <h1>Edit Attendant</h1>
              <BadgeForm
                onSubmit={this.handleSubmit}
                onChange={this.handleChange}
                formValues={this.state.form}
                error={this.state.error}
              />
            </div>
          </div>
        </div>
      </React.Fragment>
    );
  }

  fetchData = async () => {
    this.setState({ loading: true, error: null });

    try {
      console.log(this.props.match.params.badgeId);
      const data = await api.badges.read(this.props.match.params.badgeId);

      this.setState({ loading: false, form: data });
    } catch (error) {
      this.setState({ loading: false, error: error });
    }
  };
}

export default BadgeEdit;
