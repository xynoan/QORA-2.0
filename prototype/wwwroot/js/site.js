// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let hamburger = document.querySelector('.hamburger');
let navMenu = document.querySelector('.nav-menu');
let college = document.getElementById("CCS");
let popupDiv = document.getElementById('profileDiv');
let filterDiv = document.getElementById('filter-menu');
let academicYear = document.getElementById('academicYear');
let collegeProgram = document.getElementById('collegeProgram');
let section = document.getElementById('section');
let statusDiv = document.getElementById('status');

function toggleMenu() {
    hamburger.classList.toggle('active');
    navMenu.classList.toggle('active');
}

function toggleProgram() {
    college.classList.toggle('active');
}

function toggleProfile() {
    popupDiv.classList.toggle('active');
}
function toggleSave() {
    alert("Saved changes.");
    window.location.href = "/";
}

function toggleFilter() {
    filterDiv.classList.toggle('active');
    removeActiveClassFromAll(academicYear, collegeProgram, section, statusDiv);
}

function toggleAcademicYear() {
    academicYear.classList.toggle('active');
    removeActiveClassFromAll(collegeProgram, section, statusDiv);
}

function toggleCollegeProgram() {
    collegeProgram.classList.toggle('active');
    removeActiveClassFromAll(academicYear, section, statusDiv);
}

function toggleSection() {
    section.classList.toggle('active');
    removeActiveClassFromAll(academicYear, collegeProgram, statusDiv);
}

function toggleStatus() {
    statusDiv.classList.toggle('active');
    removeActiveClassFromAll(academicYear, collegeProgram, section);
}

function removeActiveClassFromAll(...elements) {
    elements.forEach(element => {
        if (element.classList.contains('active')) {
            element.classList.remove('active');
        }
    });
}

document.addEventListener("DOMContentLoaded", () => {
    // hamburger
    let QCIAN = document.getElementById("be_a_QCIAN");
    let subMenuQCIAN = document.getElementById("qcian-Submenu");
    let programs = document.getElementById("programsOffered");
    let subMenuPrograms = document.getElementById("programsSubmenu");
    let hamburgerNav = document.getElementById("hamburgerNav");

    QCIAN.addEventListener("click", () => {
        subMenuQCIAN.classList.toggle("active");
    });

    programs.addEventListener("click", () => {
        subMenuPrograms.classList.toggle("active");
    });

    QCIAN.addEventListener('mouseenter', () => {
        hamburgerNav.appendChild(subMenuQCIAN);
        subMenuQCIAN.classList.add("active");
        subMenuPrograms.remove();
    });

    programs.addEventListener('mouseenter', () => {
        hamburgerNav.appendChild(subMenuPrograms);
        subMenuPrograms.classList.add("active");
        subMenuQCIAN.remove();
    });
    // form
    let previousButton = document.getElementById("previousButton");

    if (previousButton) {
        previousButton.addEventListener("click", () => {
            window.history.back();
        });
    }

    // OTP
    const inputs = document.querySelectorAll("#otp > *[id]");
    for (let i = 0; i < inputs.length; i++) {
        inputs[i].addEventListener("keydown", function (event) {
            if (event.key === "Backspace") {
                inputs[i].value = "";
                if (i !== 0) inputs[i - 1].focus();
            } else {
                if (i === inputs.length - 1 && inputs[i].value !== "") {
                    return true;
                } else if (event.keyCode > 47 && event.keyCode < 58) {
                    inputs[i].value = event.key;
                    if (i !== inputs.length - 1) inputs[i + 1].focus();
                    event.preventDefault();
                } else if (event.keyCode > 64 && event.keyCode < 91) {
                    inputs[i].value = String.fromCharCode(event.keyCode);
                    if (i !== inputs.length - 1) inputs[i + 1].focus();
                    event.preventDefault();
                }
            }
        });
    }

    // footer
    let date = new Date().getFullYear();
    document.getElementById("year").innerHTML = date;

    // submit image
    const actualBtn = document.getElementById('actual-btn');
    const imageContainer = document.getElementById('image-container');

    if (actualBtn) {
        actualBtn.addEventListener('change', function () {
            const file = this.files[0];

            if (file) {
                const reader = new FileReader();
                reader.onload = function (event) {
                    const imageUrl = event.target.result;
                    const imgElement = document.createElement('img');
                    imgElement.src = imageUrl;
                    imgElement.alt = 'Selected Image';
                    imgElement.style.borderRadius = "inherit";
                    imgElement.style.maxWidth = '100%'; // Ensure the image fits within the container
                    const label = imageContainer.querySelector('label');
                    const span = imageContainer.querySelector('span');
                    if (label) label.remove();
                    if (span) span.remove();
                    const existingImages = imageContainer.querySelectorAll('img');
                    existingImages.forEach(img => img.remove());
                    imageContainer.appendChild(imgElement);
                };
                reader.readAsDataURL(file);
            } else {
                console.log('No file selected');
            }
        });
    }
});

document.addEventListener("click", (e) => {
    if (e.target.id !== "profile_img" && popupDiv.classList.contains("active")) {
        popupDiv.classList.toggle("active");
    }

    document.addEventListener("click", (e) => {
        if (
            !e.target.closest("#filter-menu") &&
            e.target.id !== "filter-anchor" &&
            filterDiv.classList.contains("active")
        ) {
            filterDiv.classList.remove("active");
            removeActiveClassFromAll(academicYear, collegeProgram, section, statusDiv);
        }
    });
});