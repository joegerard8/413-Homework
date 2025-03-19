import Books from './Books.tsx';
import CookieConsent from 'react-cookie-consent';
import Fingerprint from './Fingerprint.tsx';

function App() {

  return (
    <div className="">
    {/**Book component, cookie component at the bottom, as well as the unique fingerprint hash which is printed at the bottom */}
      <Books></Books>
      <CookieConsent
        location="bottom"
        buttonText="Accept"
        cookieName="Cookies"
        style={{
          background: "white",
          color: "black",
          border: "2px solid black",
          fontWeight: "bold",
          textAlign: "center",
        }}
        buttonStyle={{
          background: "blue",
          color: "white",
          borderRadius: "5px",
          fontWeight: "bold",
        }}
        expires={150}
      >
        This site uses cookies to enhance user experience.
      </CookieConsent>
      <Fingerprint/>


    </div>
  )
}

export default App
