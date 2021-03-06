//const BASE_URL = "../../api";
const BASE_URL = "https://localhost:44338/api";

async function callApi(endpoint, options = {}) {
  options.headers = {
    "Content-Type": "application/json",
    Accept: "application/json"
  };

  const url = BASE_URL + endpoint;
  const response = await fetch(url, options);
  const data = await response.json();

  return data;
}

const api = {
  badges: {
    list() {
      console.log("BASE_URL: " + BASE_URL);
      return callApi("/badges");
    },
    create(badge) {
      return callApi(`/badges`, {
        method: "POST",
        body: JSON.stringify(badge)
      });
    },
    read(badgeId) {
      return callApi(`/badges/${badgeId}`);
    },
    update(badgeId, update) {
      return callApi(`/badges/${badgeId}`, {
        method: "PUT",
        body: JSON.stringify(update)
      });
    },
    // Lo hubiera llamado `delete`, pero `delete` es un keyword en JavaScript asi que no es buena idea :P
    remove(badgeId) {
      return callApi(`/badges/${badgeId}`, {
        method: "DELETE"
      });
    }
  }
};

export default api;
