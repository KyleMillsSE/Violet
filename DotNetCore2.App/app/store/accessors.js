export const isLoginPage = ({ route }) => route.path.indexOf('/login') !== -1;

export const shouldDisplayNav = ({ route }, getters) => (route.path ? !getters.isLoginPage : false);

export const getToken = (state) => state.auth.token;

export const isAuthenticated = ({ route }, getters) => (getters.getToken ? true : false);



