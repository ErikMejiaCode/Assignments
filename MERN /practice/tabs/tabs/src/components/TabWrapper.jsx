import React from "react";

const TabWrapper = (props) => {
    const { tabs, setTabs } = props;
    const {isSelected} = tabs;

    const tabClickHandler = (e, index) => {
        let newArr = [...tabs];
        newArr.forEach((tab, i) => {
            tab.isSelected = false;
        });
        newArr[index] = {...newArr[index], isSelected: true}
        setTabs(newArr);
    }

    return (
        <>
            {
                tabs.map((tab, i) => {
                    return <button
                    onClick={(e) => {
                        tabClickHandler(e, i)
                    }}
                    style={ tab.isSelected ? {backgroundColor: "black", color: "white"} : {backgroundColor: "white", color:"black"}}
                    role={"group"}
                    key={i}
                    >
                        {tab.name}
                    </button>
                })
            }
            {
                tabs.map((tab, i) => {
                    return <>
                        {
                            tab.isSelected && <p>{tab.message}</p>
                        }
                    </>
                })
            }
        </>
    )
}


export default TabWrapper;