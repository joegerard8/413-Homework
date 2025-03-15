// importing app css, and the two components we created. 
import './App.css'
import BowlersList from './BowlersList'
import Header from './Header'

function App() {
// main app function. calls the header and the bowlers list components and then renders them. awesome stuff. 
  return (
    <>
      <Header/>
      <BowlersList/>
    </>
  )
}

export default App
