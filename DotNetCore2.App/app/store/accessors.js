// check if current path is /auth/*
export const isLoginPage = ({ route }) => route.path.indexOf('/login') !== -1

// check if navigation should be displayed
// if route.path does not exist yet returns false
export const shouldDisplayNav = ({ route }, getters) => (route.path ? !getters.isLoginPage : false);

export const isAuthenticated = ({ route }, state) => (!state.auth ? false : state.auth.token ? true : false);

export const getToken = (state) => state.auth.token 

