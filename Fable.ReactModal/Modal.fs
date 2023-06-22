module Fable.ReactModal

open Browser.Types
open Fable.Core
open Fable.Core.JsInterop
open Fable.React

type IModalOption = interface end

type IOnAfterOpenCallbackOptions =
    /// overlay element reference
    abstract overlayEl: Element with get

    /// content element reference
    abstract contentEl: HTMLDivElement with get

[<Erase>]
type ModalOption =
    /// Boolean describing if the modal should be shown or not. Defaults to false.
    static member inline isOpen (value: bool): IModalOption = !!("isOpen", value)

    /// String value of an id attribute to be applied to the modal content.
    static member inline id (value: string): IModalOption = !!("id", value)

    /// String value of data-test-id attibute to be applied to to the modal content.
    static member inline testId (value: string): IModalOption = !!("testId", value)

    /// String className to be applied to the portal. Defaults to "ReactModalPortal".
    static member inline portalClassName (value: string): IModalOption = !!("portalClassName", value)

    /// String className to be applied to the document.body (must be a constant string). When set to null it doesn't add any class to document.body.
    static member inline bodyOpenClassName (value: string): IModalOption = !!("bodyOpenClassName", value)

    /// String className to be applied to the document.html (must be a constant string). Defaults to null.
    static member inline htmlOpenClassName (value: string): IModalOption = !!("htmlOpenClassName", value)

    /// String or object className to be applied to the modal content.
    static member inline className (value: string): IModalOption = !!("className", value)

    /// String or object className to be applied to the overlay.
    static member inline overlayClassName (value: string): IModalOption = !!("overlayClassName", value)

    /// Set this to properly hide your application from assistive screenreaders and other assistive technologies while the modal is open.
    static member inline appElement (value: U4<HTMLElement, seq<HTMLElement>, HTMLCollection, NodeList>): IModalOption = !!("appElement", value)

    /// Function that will be run after the modal has opened.
    static member inline onAfterOpen (f: IOnAfterOpenCallbackOptions -> unit): IModalOption = !!("onAfterOpen", f)

    /// Function that will be run after the modal has closed.
    static member inline onAfterClose (f: unit -> unit): IModalOption = !!("onAfterClose", f)

    /// Function that will be run when the modal is requested to be closed, prior to actually closing.
    static member inline onRequestClose (f: U2<MouseEvent, KeyboardEvent> -> unit): IModalOption = !!("onRequestClose", f)

    /// Number indicating the milliseconds to wait before closing the modal. Defaults to zero (no timeout).
    static member inline closeTimeoutMS (value: int): IModalOption = !!("closeTimeoutMS", value)

    /// Boolean indicating if the appElement should be hidden. Defaults to true.
    static member inline ariaHideApp (value: bool): IModalOption = !!("ariaHideApp", value)

    /// Boolean indicating if the modal should be focused after render
    static member inline shouldFocusAfterRender (value: bool): IModalOption = !!("shouldFocusAfterRender", value)

    /// Boolean indicating if the overlay should close the modal. Defaults to true.
    static member inline shouldCloseOnOverlayClick (value: bool): IModalOption = !!("shouldCloseOnOverlayClick", value)

    /// Boolean indicating if pressing the esc key should close the modal
    static member inline shouldCloseOnEsc (value: bool): IModalOption = !!("shouldCloseOnEsc", value)

    /// Boolean indicating if the modal should restore focus to the element that had focus prior to its display.
    static member inline shouldReturnFocusAfterClose (value: bool): IModalOption = !!("shouldReturnFocusAfterClose", value)

    /// Boolean indicating if the modal should use the preventScroll flag when restoring focus to the element that had focus prior to its display.
    static member inline preventScroll (value: bool): IModalOption = !!("preventScroll", value)

    /// Function that will be called to get the parent element that the modal will be attached to.
    static member inline parentSelector (f: unit -> HTMLElement): IModalOption = !!("parentSelector", f)

    /// <summary>Additional aria attributes.</summary>
    /// <param name="labelledBy">Defines a string value that labels the current element.</param>
    /// <param name="describedBy">Identifies the element (or elements) that describes the object.</param>
    /// <param name="modal">Indicates whether an element is modal when displayed.</param>
    static member inline aria (?labelledBy: string, ?describedBy: string, ?modal: bool): IModalOption = !!("aria", {| labelledby = labelledBy; describedby = describedBy; modal = modal |})

    /// Additional data attributes to be applied to to the modal content in the form of "data-*"
    static member inline data (value: obj): IModalOption = !!("data", value)

    /// String indicating the role of the modal, allowing the 'dialog' role to be applied if desired. Defaults to "dialog".
    static member inline role (value: string): IModalOption = !!("role", value)

    /// String indicating how the content container should be announced to screenreaders.
    static member inline contentLabel (value: string): IModalOption = !!("contentLabel", value)

    /// Function accepting the ref for the content
    static member inline contentRef (f: HTMLDivElement -> unit): IModalOption = !!("contentRef", f)

    /// Function accepting the ref for the overlay
    static member inline overlayRef (f: HTMLDivElement -> unit): IModalOption = !!("overlayRef", f)

[<Erase>]
type Modal =
    static member inline render (options: seq<IModalOption>) (children: seq<ReactElement>) = Fable.React.ReactBindings.React.createElement (import "ReactModal" "react-modal", createObj !!options, children)

