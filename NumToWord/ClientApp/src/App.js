import React, { useState } from "react";
import axios from "axios";
import "./custom.css"
function App() {
    // State variables
    const [number, setNumber] = useState("0");
    const [words, setWords] = useState("");
    const [error, setError] = useState('');

    // Handler function to update the input number
    const handleChange = (event) => {
        setNumber(event.target.value);

    };

    // This is a handler function that sends a GET request to the backend and updates the output words
    const handleSubmit = async (event) => {
        event.preventDefault();
        const value = event.target.querySelector('.input').value;
        // Define the regular expression for a valid number with comma and limit the integer part to 99999999
        const regex = /^[0-9]{1,3}( ?[0-9]{3})*(,[0-9]{1,2})?$/;
        if (value) {
            if (regex.test(value)) {
                setError('');
                try {
                    const num = parseFloat(number.replace(/,/g, '.').replace(/ /g, ''));
                    const response = await axios.get(
                        `http://localhost:5177/converter?number=${num}`
                    );

                    // Set the output words to the response data
                    setWords(response.data);
                } catch (error) {
                    console.error(error);
                    setError(error);
                    setWords('');
                }
            } else {
                setError('Please enter a valid number. The maximum dollar is 999 999 999 and maximum cents is 99. The separator is comma. For example, 123 456 789,99 is a valid number.');
                setWords('');
            }
        }
        else {
            setError('Please enter a number to convert.');
            setWords('');
        }
        
    };

    // This is the JSX code for rendering the input form and the output text
    return (
        <div>
            <h1 className="heading">Coding Task</h1>
            <div className="App">
            <p className="text">Enter your currency value in numbers</p>
            <form onSubmit={handleSubmit}>
                <input className="input" type="text" value={number} onChange={handleChange} />
                <button className="button" type="submit">Convert</button>
            </form>
                <p className="text">The currency in words is: </p>
                <p className="result">{words}</p>
                <p className="error">{error}</p>
            </div>
            <p className="footer">Kalaivanan Thirusangu</p>
        </div>
    );
}

export default App;
