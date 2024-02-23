import axios from "axios";

export async function CreateProject(props) {
  const response = await axios
    .post("api/Projects/create", {
      userId: props.userId,
      title: props.projectTitle,
      description: props.projectDescription,
      htmlCode: props.htmlCode,
      cssCode: props.cssCode,
      jsCode: props.jsCode,
      totalTokens: 0, //********************************** HANDLE WHENEVER ************************************/
      totalMoney: 0 //********************************** HANDLE WHENEVER ************************************/
    })
    .catch(function (error) {
      alert("Error saving project, there is no connection to the server");
      console.log("Error saving project:", error);
    });
  return response.data;
}

export async function GetProjectsByUserId(userId) {
  const response = await axios
    .get(`api/Projects/user/${userId}`)
    .catch(function (error) {
      alert("Error fetching projects, there is no connection to the server");
      console.log("Error fetching projects:", error);
    });
  return response.data;
}

export async function GetProjectById(projectId) {
  const response = await axios.get(`api/Projects/project/${projectId}`);
  return response.data;
}

export async function UpdateProject(props) {
  const response = await axios
    .put("api/Projects/update", {
      projectId: props.projectId,
      userId: props.userId,
      title: props.projectTitle,
      description: props.projectDescription,
      htmlCode: props.htmlCode,
      cssCode: props.cssCode,
      jsCode: props.jsCode,
      createdAt: props.projectCreateDate,
      totalTokens: 0, //********************************** HANDLE WHENEVER ************************************/
      totalMoney: 0 //********************************** HANDLE WHENEVER ************************************/
    })
    .catch(function (error) {
      alert("Error updating project, there is no connection to the server");
      console.log("Error updating project:", error);
    });
  return response.data;
}

export async function RemoveProjectById(projectId) {
  const response = await axios.delete(`api/Projects/delete/${projectId}`);
  alert(`Project with id ${response.data} deleted successfully`);
}

export async function RegisterUser(props) {
  const response = await axios
    .post("/register", {
      email: props.registerEmail,
      password: props.registerPassword
    })
    .catch(function (error) {
      alert("Error registering user, there is no connection to the server");
      console.log("Error registering user:", error);
    });
  return response.data;
}

export async function loginUser(props) {
  const response = await axios
    .post("/login?useCookies=true", {
      email: props.loginEmail,
      password: props.loginPassword
    })
    .catch(function (error) {
      alert("Error logging in, there is no connection to the server");
      console.log("Error logging in:", error);
    });
  return response.data;
}

export async function getMe() {
  const me = await axios.get("/manage/info").catch(function (error) {
    alert("Error getting user info");
    console.log("Error getting user info:", error);
  });

  const email = me.data.email;

  const response = await axios
    .get(`api/users/${email}`)
    .catch(function (error) {
      alert("Error getting user info");
      console.log("Error getting user info:", error);
    });
  const currentUser = response.data;
  return currentUser;
}

export async function logout() {
  const response = await axios.post("/logout", {}).catch(function (error) {
    alert("Error logging out");
    console.log("Error logging out:", error);
  });
  return response;
}
