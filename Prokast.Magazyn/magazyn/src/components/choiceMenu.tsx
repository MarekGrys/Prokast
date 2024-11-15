import React from "react"
function ChoiceMenu(){
    return(
        <div className="grid grid-cols-2 bg-menuColor align-middle w-full">
            <div className="flex flex-row p-5 gap-10 text-2xl font-medium pl-10">
                <p>Opcja 1</p>
                <p>Opcja 2</p>
                <p>Opcja 3</p>
                <p>Opcja 4</p>
                <p>Opcja 5</p>
                <p>Opcja 6</p>
                <p>Opcja 7</p>
                <p>Opcja 8</p>
                <p>Opcja 9</p>
            </div>
            <div className="flex flex-row place-content-end">
                <button className="p-5 bg-menuColor   text-white border-solid border-l-2 border-black">Wyloguj</button>
            </div>
            
        </div>
        
    )
}

export default ChoiceMenu